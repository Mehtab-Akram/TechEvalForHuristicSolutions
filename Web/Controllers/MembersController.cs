using System.Linq;
using System.Web.Mvc;
using Heuristics.TechEval.Core;
using Heuristics.TechEval.Web.Models;
using Heuristics.TechEval.Core.Models;
using Newtonsoft.Json;
using System;
using System.Data.Entity.Migrations;
using System.Net;
using System.Collections.Generic;
using System.Data.Entity;

namespace Heuristics.TechEval.Web.Controllers
{

    public class MembersController : Controller
    {

        public IDataContext _context;

        public MembersController()
        {
            _context = new DataContext();
        }

        public ActionResult List()
        {
            var allMembers = _context.Members.ToList();
            var allCategories = _context.Categories.ToList();

            var viewModel = new MemberCategoryViewModel
            {
                Members = allMembers,
                Categories = allCategories
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(NewMember data)
        {

            if (EmailIsDuplicate(data))
            {
                ModelState.AddModelError("Email", "Email already exists.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                                .Where(m => m.Value.Errors.Any())
                                .Select(m => new { Property = m.Key, Message = m.Value.Errors.First().ErrorMessage });

                var errorJson = new Dictionary<string, string>();
                foreach (var error in errors)
                {
                    errorJson[error.Property] = error.Message;
                }

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(errorJson);
            }

            var newMember = new Member
            {
                Id = (data.MemberId != 0 ? data.MemberId : 0) ?? 0,
                Name = data.Name,
                Email = data.Email,
                CategoryId = data.Category,
                LastUpdated = DateTime.Now
            };

            _context.Members.AddOrUpdate(newMember);
            _context.SaveChanges();


            return Json(JsonConvert.SerializeObject(newMember));
        }

        public bool EmailIsDuplicate(NewMember data)
        {
            bool emailIsDuplicate = false;

            if (!string.IsNullOrWhiteSpace(data.Email))
            {
                emailIsDuplicate = _context.Members.Any(e => e.Email == data.Email & e.Id != data.MemberId);
            }
            return emailIsDuplicate;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Heuristics.TechEval.Core;
using Heuristics.TechEval.Web.Models;

namespace Heuristics.TechEval.Web.Controllers {

	public class CategoriesController : Controller {

		private readonly DataContext _context;

		public CategoriesController() {
			_context = new DataContext();
		}

		public ActionResult List() {
			var Category  = _context.Categories.ToList();
            List<CategoriesWithMemberCount> categoriesWithMemberCount = new List<CategoriesWithMemberCount>();
			foreach (var category in Category)
			{
				categoriesWithMemberCount.Add(new CategoriesWithMemberCount
				{
					Id = category.Id,
					Name = category.Name,
					MemberCount = _context.Members.Count(x=> x.CategoryId == category.Id)
				});
			}


            return View(categoriesWithMemberCount);
		}
	}
}
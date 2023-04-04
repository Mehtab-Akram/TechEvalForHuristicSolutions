using Heuristics.TechEval.Core;
using Heuristics.TechEval.Core.Models;
using Heuristics.TechEval.Web.Controllers;
using Heuristics.TechEval.Web.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heuristics.TechEval.Tests.Controllers
{
    [TestClass]
    public class MembersControllerTests
    {
        [TestMethod]
        public void CheckDuplicateEmail_EmailExists_ReturnsError()
        {
            // Arrange
            
            var mockContext = new Mock<IDataContext>();
            var controller = new MembersController { _context = mockContext.Object };
            var member = new NewMember { Email = "johndoe@example.com", MemberId = 1 };
            var membersList = new List<Member> { new Member { Id = 2, Email = "johndoe@example.com" } };
            var mockSet = new Mock<DbSet<Member>>();
            mockSet.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(membersList.AsQueryable().Provider);
            mockSet.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(membersList.AsQueryable().Expression);
            mockSet.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(membersList.AsQueryable().ElementType);
            mockSet.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(membersList.AsQueryable().GetEnumerator());

            mockContext.Setup(m => m.Members).Returns(mockSet.Object);

            //controller.ValidateModel(member);
            // Act
            controller.EmailIsDuplicate(member);

            // Assert
            Assert.IsTrue(controller.EmailIsDuplicate(member));
        }
    }
}

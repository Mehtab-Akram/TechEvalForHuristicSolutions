using System.Web.Mvc;

namespace Heuristics.TechEval.Web.Controllers {

	public class HomeController : Controller {
		
		public ActionResult Index() {
			return View();
		}

		public ActionResult Setup() {
			return View();
		}

		public ActionResult Requirements() {
			return View();
		}
	}
}
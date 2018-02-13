using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxOrnek.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities _dbContext;
        public HomeController()
        {
            _dbContext = new NorthwindEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCategory(int id)
        {
            Category cat = _dbContext.Categories.FirstOrDefault(x => x.CategoryID == id);
            return Json(cat, JsonRequestBehavior.AllowGet);
        }

    }
}
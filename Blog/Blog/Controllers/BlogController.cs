using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/Images/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            var rlink = "Blog/Images/" + fileName;
            return Json(new { link = new UrlHelper(Request.RequestContext).Content("~/Images/" + fileName) }, JsonRequestBehavior.AllowGet);
        }
    }
}
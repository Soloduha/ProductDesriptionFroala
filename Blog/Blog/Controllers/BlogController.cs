using Blog.Models;
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
            //var fileName = Path.GetFileName(file.FileName);
            var fileName = Guid.NewGuid().ToString()+".jpg";
            var rootPath = Server.MapPath("~/Images/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            var rlink = "Blog/Images/" + fileName;
            return Json(new { link = new UrlHelper(Request.RequestContext).Content("~/Images/" + fileName) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveImage(string Name)
        {
            string path = Server.MapPath(Name);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return View("Add");
        }


        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveHtml(string content)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Contents.Add(new Models.Content()
                {
                    Paste = content.ToString(),
                    LastChanges = DateTime.Now
                });
                context.SaveChanges();
            }
            return View("Add");
        }
    }
}
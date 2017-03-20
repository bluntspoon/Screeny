using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Screeny.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase photo)
        {
            var directory = Server.MapPath("~/screenshots");
            if (photo != null && photo.ContentLength > 0)
            {
                try
                {
                    CreateFolderIfNeeded(directory);
                    var fileName = Path.GetFileName(photo.FileName);
                    fileName = string.Format(@"{0}_" + fileName, DateTime.Now.ToString("yyyyMMddHHmmss"));
                    photo.SaveAs(Path.Combine(directory, fileName));
                    ViewBag.Message = "File uploaded successfully!\n New Filename: " + fileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View("Index");
        }

        public ActionResult Browse()
        {
            ViewBag.Directory = Server.MapPath("~/screenshots"); 
            return View();
        }

        private void CreateFolderIfNeeded(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                }
            }
        }

    }
}
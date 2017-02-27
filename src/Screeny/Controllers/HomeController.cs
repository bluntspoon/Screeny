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
      ViewBag.Message = "";
      return View();
    }

    [HttpPost]
    public ActionResult Index(HttpPostedFileBase photo)
    {
      string directory = ConfigurationManager.AppSettings["PhotosStoragePath"];

      if (photo != null && photo.ContentLength > 0)
      {
        try
        {
          var fileName = Path.GetFileName(photo.FileName);
          photo.SaveAs(Path.Combine(directory, fileName));
          ViewBag.Message = "File uploaded successfully";
        }
        catch (Exception ex)
        {
          ViewBag.Message = "ERROR:" + ex.Message.ToString();
        }
      }
      else
      {
        ViewBag.Message = "You have not specified a file.";
      }

      return View();
    }

    private bool CreateFolderIfNeeded(string path)
    {
      bool result = true;
      if (!Directory.Exists(path))
      {
        try
        {
          Directory.CreateDirectory(path);
        }
        catch (Exception)
        {
          /*TODO: You must process this exception.*/
          result = false;
        }
      }
      return result;
    }

  }
}
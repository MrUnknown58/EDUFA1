using EDUFA1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using EDUFA1.DataModel;
using ezy.school.models.Mapper;

namespace EDUFA1.Controllers
{
    public class HomeController : Controller
    {
        EdufaEntities db = new EdufaEntities();
        public ActionResult Index()
        {
            return RedirectToAction("FrontPage");
        }
        public ActionResult FrontPage()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult KnowMore()
        {
            return View();
        }
        public ActionResult UploadMaterials()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult ShowMaterials()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                        var p = db.UploadedFiles.Where(m => m.isDeleted == false && m.isApproved).ToList();
                        return View(p);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return View();
                }
            }
        }
        public ActionResult ApprovedMaterials(UploadedMaterialsModelView model)
        {
            UploadedFileWithCredentials f=new UploadedFileWithCredentials();
            f.LoginID = model.LoginID;
            f.Password = model.Password;
            if (model.LoginID == "admin" && model.Password == "admin")
            {
                try
                {
                    f.files = db.UploadedFiles.Where(m => m.isDeleted == false && m.isApproved == false).ToList();
                }
                catch(Exception e)
                {
                    return View(f);
                }
                return View(f);
            }
            else
                return View(f);
                //return RedirectToAction("Error");
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult SaveFile(UploadedMaterialsModelView model)
        {
            var im1 = Path.GetFileName(model.FileName.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), im1);
                model.FileName.SaveAs(path);
                model.FilePath = im1;
            UploadedFile files = UploadedFilesMapping.Map(model);
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    db.UploadedFiles.Add(files);
                    db.SaveChanges();
                    scope.Complete();
                    return RedirectToAction("FrontPage");

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return RedirectToAction("FrontPage");
                }
            }
        }
        public ActionResult SaveMaterial(int? num,string ID,string Pass)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var d=db.UploadedFiles.Where(m => m.Sl_No == num).FirstOrDefault();
                    d.isApproved = true;
                    db.SaveChanges();
                    scope.Complete();
                    return RedirectToAction("ApprovedMaterials",new UploadedMaterialsModelView() { LoginID=ID,Password=Pass});

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return RedirectToAction("FrontPage");
                }
            }
        }
        public ActionResult DeleteMaterial(int? num,string ID,string Pass)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var d = db.UploadedFiles.Where(m => m.Sl_No == num).FirstOrDefault();
                    d.isDeleted = true;
                    db.SaveChanges();
                    scope.Complete();
                    return RedirectToAction("ApprovedMaterials",new UploadedMaterialsModelView { LoginID=ID,Password=Pass});

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return RedirectToAction("FrontPage");
                }
            }
        }
        public ActionResult AdminLogin()
        {
            return View();
        }


    }
}
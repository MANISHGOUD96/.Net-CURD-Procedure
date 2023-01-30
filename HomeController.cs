using MK.StordProcedureMVC.DB_Connection;
using MK.StordProcedureMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MK.StordProcedureMVC.Controllers
{
    [Authorize]
    [RoutePrefix("Manish")]
    public class HomeController : Controller
    {
        //------------Read the value from Table-------------------

        public ActionResult Index()
        {
            emEntities DB = new emEntities();

            //First Approach
            //var resdata = DB.GetAllData().ToList();
            //Second Approach
            //var resdata = DB.Database.SqlQuery<EmpModles>("exec GetAllData").ToList();
            //Third Approach

            var resdata = DB.Database.SqlQuery<EmpModles>("GetAllData").ToList();
            return View(resdata);
        }
        //---------------Insert the value in table---------------------
        [HttpGet]
     
        public ActionResult Insert()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(EmpModles obj)
        {
            emEntities DB = new emEntities();
            DB.Insertvalue(obj.EmpId, obj.Name, obj.Email, obj.Phone, obj.AdressId, obj.DeptId, obj.Village, obj.PinCode, obj.BuildingNo, obj.District, obj.DepCode,obj.DepName);

            return RedirectToAction("Index");
        }

        //-----------------Delete table---------------------
        public ActionResult Delete(int EmpId,  int adressId, int deptId)
        
        {
            emEntities DB = new emEntities();
            DB.DeletTable(EmpId, adressId, deptId);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        //--------------------Edit Table----------------------
        [HttpGet]
        public ActionResult Edit(int EmpId)
        {
            emEntities DB = new emEntities();

            var update = DB.GetAllDataWithId(EmpId).ToList();
            return View(update[0]);
          }

        [HttpPost]
        public ActionResult Edit(EmpModles obj)
        {
          emEntities DB = new emEntities();           
          DB.UpdateTable(obj.EmpId, obj.Name, obj.Email, obj.Phone, obj.AdressId, obj.Village, obj.PinCode, obj.BuildingNo, obj.District, obj.DeptId, obj.DepCode, obj.DepName);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
        //--------------------Login Page-----------------

       [AllowAnonymous]
        [HttpGet]
        public ActionResult logien()
        {
            return View();
        }

       [AllowAnonymous]
        [HttpPost]
        public ActionResult logien(LogienModel obj)
        {
            emEntities DB = new emEntities();
            var rev = DB.logiens.Where(a => a.Email == obj.Email).FirstOrDefault();
            if (rev == null)
            {
                TempData["Ivalid"] = "Inavalid Email Id.........";
            }
            else
            {     
                if(rev.Email==obj.Email && rev.Password == obj.Password)
                {
                    Session["Email"] = rev.Email;
                    FormsAuthentication.SetAuthCookie(rev.Email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InvalidPass"]= "Enter your correct Password.......";
                }
            }
            return View();
        }
        //--------------------LogOut Page-----------------
        public ActionResult LogOut()
        {
           FormsAuthentication.SignOut();
            Session.Clear();
           return RedirectToAction("Logien");
        }

        [Route("Abhi")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Mkg/Hi/Chetu")]

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
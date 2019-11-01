using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;
namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class CategoryController : BaseAdminController
    {
        
        // GET: Admin/Category
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Category category) {

            if (ModelState.IsValid) {
            try
            {
                objBs.categoryBs.Insert(category);
                TempData["Msg"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
            }
            else
            {
                return View("Index");

            }


        }


    }
}
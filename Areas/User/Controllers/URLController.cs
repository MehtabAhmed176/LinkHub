using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [Authorize(Roles = "A,U")]
    public class URLController : Controller
    {
        //UrlBs objBs;
        //CategoryBs objcatBs;
        //UserBs objUserBs;
        private UserAreaBs objBs;
        public URLController()
        {
            objBs = new UserAreaBs();
            //objcatBs = new CategoryBs();
            //objUserBs = new UserBs();


        }
        // GET: User/URL Create
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url myurl)
        {
            //"Create", "URL", FormMethod.Post
            //
/*< h2 > Manage Urls </ h2 >
   @if(TempData["Msg"] != null)
{< div class="alert alert-dismissable alert-info">
        <button type = "button" class="close" data-dismiss="alert">×</button>
        @TempData["Msg"].ToString()
    </div>}*/
            try
            {
                if (ModelState.IsValid)
                {
                    
                    objBs.urlBs.Insert(myurl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
            }
           

            }
        

    
}
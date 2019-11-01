using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {

        // GET: Common/BrowseURLs
    
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var urls = objBs.userBs.GetAll();
            switch (SortBy)
            {
                case "UserEmail":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Role":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

            
               

                default:
                    urls = urls.OrderBy(x => x.UserEmail).ToList();
                    break;
            }
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            urls = urls.Skip((page - 1) * 10).Take(10);
            return View(urls);
        }
    }
}
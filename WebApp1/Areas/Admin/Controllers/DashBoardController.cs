using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Common;

namespace WebApp1.Areas.Admin.Controllers
{
    [Authorize]
    [CustomActionFilter]
    [ExceptionHandlerFilter]
    public class DashBoardController : Controller
    {
        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}
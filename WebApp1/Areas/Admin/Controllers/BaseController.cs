using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp1.Models;

namespace WebApp1.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected void SetSuccessNotification()
        {
            //string controller = RouteData.GetRequiredString("controller");
            string action = RouteData.GetRequiredString("action");
            if ("edit" == action?.ToLower())
            {
                TempData.Add("Message", "Item is saved.");
            }
            else if ("deleteconfirmed" == action?.ToLower())
            {
                TempData.Add("Message", "Item is deleted.");
            }
            else
            {
                TempData.Add("Message", "Action is succeed.");
            }

        }

        protected Account CurrentAccount
        {
            get
            {
                Account account = Session["shop:user"] as Account;
                if (account != null)
                {
                    return account;
                }
                throw new InvalidOperationException("Invalid user state");
            }
        }
    }
}
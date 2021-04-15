using WebApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApp1.Common
{
	public class CustomActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			var controller = filterContext.Controller as Controller;
			string actionName = filterContext.ActionDescriptor.ActionName;
			string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
			if (controller != null)
			{
				controller.ViewBag.DebugMessage = string.Format( "Debug message:{0}, {1}", controllerName, actionName);
			}
		}
	}
}

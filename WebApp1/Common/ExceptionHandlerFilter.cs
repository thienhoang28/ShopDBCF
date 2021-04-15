using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace WebApp1.Common
{
	public class ExceptionHandlerFilter : HandleErrorAttribute
	{
		private static Logger logger = LogManager.GetLogger(Constants.LoggerName.DEFAULT);
		public override void OnException(ExceptionContext filterContext)
		{
			base.OnException(filterContext);
			if (!filterContext.ExceptionHandled)
			{
				logger.Debug(filterContext.Exception, filterContext.Exception.Message ?? "Unknow error has occured.");
			}
		}
	}
}
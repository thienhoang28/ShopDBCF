using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Common
{
	public static class MyHelper
	{
		public static string ToProductImageUrl(this string relativeUrl)
		{
			string productImageDir = System.Configuration.ConfigurationManager.AppSettings.Get("shop:uploadsDir:products");
			string host = System.Configuration.ConfigurationManager.AppSettings.Get("shop:host");
			if (string.IsNullOrEmpty(productImageDir))
			{
				throw new Exception("Configuration missed: \"shop:uploadsDir:products\"");
			}
			if (string.IsNullOrEmpty(host)) {
				throw new Exception("Configuration missed: \"shop:host\"");
			}

			return host + HttpContext.Current.Server.UrlDecode(relativeUrl).Remove(0, 1);  //remove ~
		}
	}
}
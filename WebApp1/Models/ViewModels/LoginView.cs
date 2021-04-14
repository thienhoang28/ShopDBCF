using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models.ViewModels
{
    public class LoginView
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public bool RememberLogin { get; set; }
    }
}
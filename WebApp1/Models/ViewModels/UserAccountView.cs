using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models.ViewModels
{
    public class UserAccountView
    {
        public long Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Roles { get; set; }
        public short Locked { get; set; }

        public UserAccountView() { }
        public UserAccountView(User user)
        {
            Id = user.Id;
            LoginName = user.Account.LoginName;
            Password = string.Empty;
            Email = user.Account.Email;
            DisplayName = user.DisplayName;
            Roles = user.Roles;
            Locked = user.Account.Locked;
        }

        public void CopyToUser(ref User user)
        {
            if (user.Account == null)
            {
                user.Account = new Account();
            }
            user.Account.LoginName = LoginName;
            user.Account.Password = Password;
            user.DisplayName = DisplayName;
            user.Account.Email = Email;
            user.Account.Locked = Locked;
            user.Roles = Roles;
        }
    }
}
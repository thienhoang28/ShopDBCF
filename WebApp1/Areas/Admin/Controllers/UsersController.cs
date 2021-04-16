using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp1.Common;
using WebApp1.Models;
using WebApp1.Models.ViewModels;

namespace WebApp1.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [CustomActionFilter]
    [ExceptionHandlerFilter]
    public class UsersController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Account);
            return View(users.ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                viewModel.CopyToUser(ref user);
                db.Users.Add(user);
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }

            //ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", user.AccountId);
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);
            return View(viewModel);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            UserAccountView viewModel = new UserAccountView(user);
            //ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", user.AccountId);
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);
            return View(viewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAccountView viewModel)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Find(viewModel.Id);
                if (viewModel.Password == null || string.IsNullOrEmpty(viewModel.Password))
                {
                    user.Account.LoginName = viewModel.LoginName;
                    user.DisplayName = viewModel.DisplayName;
                    user.Account.Email = viewModel.Email;
                    user.Roles = viewModel.Roles;
                }
                else
                {
                    viewModel.CopyToUser(ref user);
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }
            //ViewBag.AccountId = new SelectList(db.Accounts, "Id", "LoginName", user.AccountId);
            ViewBag.RolesList = new SelectList(DataUtils.GetRolesList(), "Key", "Value", viewModel.Roles);
            return View(viewModel);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            SetSuccessNotification();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

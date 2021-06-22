﻿using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(login.UserName, Encryptor.EncryptMD5(login.Password));
                if (result == 1)
                {
                    //ModelState.AddModelError("","Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index", "Home");

                }
                else if(result == 2)
                {
                    ModelState.AddModelError("", " Tài khoản đang bị khóa");
                }
                if(result==0)
                {
                    ModelState.AddModelError("", " Tài khoản hoặc mật khẩu sai");
                }
            }
            return View("Index");

        }
    }
}
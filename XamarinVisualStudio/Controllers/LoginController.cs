using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using BizLogin = XamarinVisualStudio.Biz.Data;
using XamarinVisualStudio.Biz;
using AutoMapper;
using ModelLogin = XamarinVisualStudio.Models;


namespace XamarinVisualStudio.Controllers
{
	public class LoginController : Controller
	{
		public LoginController()
		{
			Mapper.CreateMap<ModelLogin.Login, BizLogin.Login>();
		}
		XamarinLogin xamarinLogin = new XamarinLogin();
		//
		// GET: /Login/
		[HttpPost]
		public ActionResult Login()
		{
			BizLogin.Login _login = new BizLogin.Login()
			{
				UserID = 1,
				UserName = "test",
				UserPassword = "test",
				rowguid = new Guid(),
				DTCreate = DateTime.UtcNow,
				DTUpdate = DateTime.UtcNow
			};

			Dictionary<string, object> Metadata = new Dictionary<string, object>();
			Metadata.Add("Key_Information", "abcd");
			xamarinLogin.Add(_login, Metadata);
			return View();
		}
		[HttpGet]
		public ActionResult PreLogin()
		{
			string UserName = Request.QueryString["UserName"];
			string Password = Request.QueryString["Password"];
			//UserName = "145035029143790340"; //convert to hexa-> reverse-> convert to decimal-> multi by 23
			// HEX+			--> DEC+ --> reverse  --> /23
			Dictionary<string, object> Metadata = new Dictionary<string, object>();
			Metadata.Add("UserName", UserName);
			Metadata.Add("Password", Password);
			BizLogin.Login _login = xamarinLogin.Validate(Metadata);
			ModelLogin.Login _modelLogin = new ModelLogin.Login();
			Mapper.Map<ModelLogin.Login, BizLogin.Login>(_modelLogin);
			if (_login != null)
				return View("AddPost", "AuthorMainPage", _modelLogin);
			else
				return View("Login");
		}
		[HttpPost]
		public ActionResult AuthorLogin()
		{
			ModelLogin.Login _login = new ModelLogin.Login();
			_login.UserName = "Test";
			return View("AddPost", "AuthorMainPage", _login);
		}
	}
}

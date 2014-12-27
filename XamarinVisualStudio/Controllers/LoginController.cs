using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XamarinVisualStudio.Biz.Data;
using XamarinVisualStudio.Biz;

namespace XamarinVisualStudio.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
		[HttpPost]
        public ActionResult Login()
        {
			Login _login = new Login()
			{
				UserID = 1,
				UserName = "test",
				UserPassword = "test",
				rowguid = new Guid(),
				DTCreate = DateTime.UtcNow,
				DTUpdate = DateTime.UtcNow
			};
			XamarinLogin xamarinLogin = new XamarinLogin();
			Dictionary<string,object> Metadata = new Dictionary<string,object>();
			Metadata.Add("Key_Information", "abcd");
			xamarinLogin.Add(_login, Metadata);
            return View();
        }
		[HttpGet]
		public ActionResult PreLogin()
		{
			return View("Login");
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using XamarinVisualStudio.Biz.Data;
using XamarinVisualStudio.Biz;

namespace XamarinVisualStudio.Controllers
{
    public class LoginController : Controller
    {
		XamarinLogin xamarinLogin = new XamarinLogin();
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
			
			Dictionary<string,object> Metadata = new Dictionary<string,object>();
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
			xamarinLogin.Validate(new Dictionary<string, object>());							//div by 23 --> +DEC -->  reverse -->convert to hexa HEX+

			return View("Login");
		}
    }
}

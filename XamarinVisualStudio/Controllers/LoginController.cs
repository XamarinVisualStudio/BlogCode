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
using System.IO;
using System.IO.Compression;
using System.Text;

namespace XamarinVisualStudio.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            Mapper.CreateMap<BizLogin.Login, ModelLogin.Login>()
                .ForMember(x => x.UserName, x => x.MapFrom(z => z.UserName));
        }
        XamarinLogin xamarinLogin = new XamarinLogin();

        //ss
        // GET: /Login/
        [HttpPost]
        public ActionResult Login()//dd
        {
            BizLogin.Login _login = new BizLogin.Login()//ff
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
            Metadata.Add("UserName", "test");
            Metadata.Add("Password", "test");
            BizLogin.Login _login = xamarinLogin.Validate(Metadata);
            ModelLogin.Login _modelLogin = new ModelLogin.Login();
            Mapper.Map<BizLogin.Login, ModelLogin.Login>(_login, _modelLogin);
            _modelLogin.BlogText = "TestBlog";
            _modelLogin.BlogTitle = "TestBlogTitle";
            if (_login != null)
                return View("AddPost", "AuthorMainPage", _modelLogin);
            else
                return View("Login");
        }
        [HttpPost]
        public ActionResult AuthorLogin(ModelLogin.Login _login)
		{
            char[] charBlogTextArray = _login.BlogText.ToCharArray();

            byte[] text = Encoding.ASCII.GetBytes(new string(charBlogTextArray));

			// Use compress method.
			byte[] compress = Compress(text);
            if (compress.Length > 200)
            {
                byte[] compressagain = Compress(compress);
                byte[] Decompressed = Decompress(compressagain);
                byte[] Decompressedagain = Decompress(Decompressed);
                string newText = System.Text.Encoding.UTF8.GetString(Decompressedagain);
                _login.UltraZipTech = true;
            }
            else
            {
                byte[] Decompressed = Decompress(compress);
                string newText = System.Text.Encoding.UTF8.GetString(Decompressed);
            }
			// Write compressed data.
			//File.WriteAllBytes("compress.gz", compress);
            return View("AddPost", "AuthorMainPage", _login);
		}
       
        private static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }
        private static byte[] Decompress(byte[] gzip)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }
}

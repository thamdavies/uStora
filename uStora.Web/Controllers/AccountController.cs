using BotDetect.Web.Mvc;
using uStora.Common;
using uStora.Model.Models;
using uStora.Web.App_Start;
using uStora.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace uStora.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng")]
        public async Task<ActionResult> Register(RegisterViewModel registerVm)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await _userManager.FindByEmailAsync(registerVm.Email);
                if (userByEmail != null)
                {
                    ModelState.AddModelError("email", "Email đã tồn tại");
                    return View(registerVm);
                }
                var userByUserName = await _userManager.FindByNameAsync(registerVm.Username);
                if (userByUserName != null)
                {
                    ModelState.AddModelError("email", "Tài khoản đã tồn tại");
                    return View(registerVm);
                }
                var user = new ApplicationUser()
                {
                    UserName = registerVm.Username,
                    Email = registerVm.Email,
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = registerVm.Fullname,
                    PhoneNumber = registerVm.PhoneNumber,
                    Address = registerVm.Address
                };

                await _userManager.CreateAsync(user, registerVm.Password);

                var adminUser = await _userManager.FindByEmailAsync(registerVm.Email);
                if (adminUser != null)
                    await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/templates/newuser.html"));
                content = content.Replace("{{Username}}", adminUser.FullName);
                content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink") + "dang-nhap.html");

                MailHelper.SendMail(adminUser.Email, "Đăng ký thành công", content);

                ViewData["SuccessMsg"] = "Đăng ký thành công";
            }

            return View();
        }
    }
}
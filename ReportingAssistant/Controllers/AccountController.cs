using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Reporting.DomainModels.Identity;
using Reporting.DomainModels.ViewModels;
using Reporting.ServiceContracts;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ReportingAssistant.Controllers
{
    public class AccountController : Controller
    {
        IAspNetUsersService userServ;

        public AccountController(IAspNetUsersService uServ)
        {
            this.userServ = uServ;
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            ApplicationUser user = userServ.FindUser(lvm.username, lvm.Password);
            if (user != null)
            {
                this.LoginUser(user);
                if (userServ.userIsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Username or Password");
                return View();
            }


        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var passHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { UserName = rvm.Username, Email = rvm.Email, PasswordHash = passHash, City = rvm.City, Address = rvm.Address, Birthday = rvm.DateOfBirth, Country = rvm.Country, PhoneNumber = rvm.Mobile };
                bool result = userServ.Create(user);

                if (result)
                {
                    //add to role
                    userServ.AddUserToRole(user.Id, "User");

                    //login
                    this.LoginUser(user);

                    //var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    //var userIdentity = userServ.identyUser(user, DefaultAuthenticationTypes.ApplicationCookie); //userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    // authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public void LoginUser(ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userServ.identyUser(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
            this.Session["User"] = user.Id;
        }

        public ActionResult UserProfile()
        {
            ApplicationUser user = userServ.FindUser(User.Identity.GetUserId());
            if (user == null) return RedirectToAction("Login");
            UserProfile userPro = new UserProfile() { userName = user.UserName, Email = user.Email, City = user.City, Country = user.Country, Mobile = user.PhoneNumber, DateOfBirth = user.Birthday };
            return View(userPro);
        }

        public ActionResult ChangePassword()
        {
            ApplicationUser user = userServ.FindUser(User.Identity.GetUserId());
            if (user == null) return RedirectToAction("Login");
            ChangePassViewModel userChange = new ChangePassViewModel() { Username = user.UserName };
            return View(userChange);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassViewModel CPV)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userServ.FindUserByName(CPV.Username);
                bool oldPassMatch = Crypto.VerifyHashedPassword(user.PasswordHash, CPV.OldPassword);
                if (oldPassMatch)
                {
                    user.PasswordHash = Crypto.HashPassword(CPV.NewPassword);
                    userServ.UpdateUser(user);
                    return Content("Password Updated Successfully");
                }
                else
                {
                    ModelState.AddModelError("My Error", "your current password is incorect");
                    return View(CPV);
                }
            }
            else
            {
                ModelState.AddModelError("My Error", "Passwords do not match");
                return View(CPV);
            }

        }

    }
}
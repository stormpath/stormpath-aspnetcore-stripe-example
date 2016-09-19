using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stormpathWebAppDemo.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace stormpathWebAppDemo.Controllers
{
    public class PremiumContentController : Controller
    {
        private readonly AccountManager accountManager;

        public PremiumContentController(AccountManager accountManager)
        {
            this.accountManager = accountManager;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            bool isPremiumUser = await accountManager.IsPremiumUser(HttpContext.User.Identity);

            if (isPremiumUser)
            {
                return View();
            }
            else
            {
                return Redirect("~/Home/BePremium");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Stormpath.SDK;
//using Stormpath.SDK.Client;
using Stormpath.SDK.Error;
using Stormpath.SDK.Application;
using Stormpath.SDK;
using System.Security.Claims;
using Stormpath.SDK.Account;
using stormpathWebAppDemo.Model;
using Stripe;
using Microsoft.Extensions.Options;
using stormpathWebAppDemo.Services;

namespace stormpathWebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly PaymentService paymentService;
        private readonly AccountManager accountManager;

        public HomeController(PaymentService paymentService, AccountManager accountManager)
        {
            this.paymentService = paymentService;
            this.accountManager = accountManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult BePremium()
        {
            return View("PremiumPayment");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentFormData formData)
        {
            
            if (paymentService.ProcessPayment(formData.Token))
            {
                await accountManager.AddUserToPremiumGroup(HttpContext.User.Identity);
                return Redirect("Index");
            }
            else
            {
                //TODO: Handle errors
                return Redirect("Error");
            }
        }
    }
}

using Stormpath.SDK;
using Stormpath.SDK.Account;
using Stormpath.SDK.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace stormpathWebAppDemo.Services
{
    public class AccountManager
    {
        private readonly IApplication stormpathApplication;
        private readonly string PREMIUM_GROUP = "Premium";

        private async Task<IAccount> GetUserAccount(IIdentity userIdentity)
        {
            return await stormpathApplication.GetAccounts().Where(x => x.Email == userIdentity.Name).FirstOrDefaultAsync();
        } 

        public AccountManager(IApplication stormpathApplication)
        {
            this.stormpathApplication = stormpathApplication;
        }

        public async Task AddUserToPremiumGroup(IIdentity userIdentity)
        {
            var premiumGroup = await stormpathApplication.GetGroups().Where(g => g.Name == PREMIUM_GROUP).FirstOrDefaultAsync();
            var account = await GetUserAccount(userIdentity);

            if (premiumGroup != null && account != null)
            {
               await premiumGroup.AddAccountAsync(account);
            }
        }

        public async Task<bool> IsPremiumUser(IIdentity userIdentity)
        {
            var isPremium = false;

            if (userIdentity != null)
            {
                var account = await GetUserAccount(userIdentity);

                if (account != null)
                {
                    isPremium = await account.GetGroups().Where(g => g.Name == PREMIUM_GROUP).AnyAsync();
                }
            }

            return isPremium;
        }
    }
}

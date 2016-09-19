using Stormpath.SDK;
using Stormpath.SDK.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stormpathWebAppDemo.Helpers
{
    public class UserHelper
    {
        private readonly Lazy<IAccount> userAccount;

        public UserHelper(Lazy<IAccount> userAccount)
        {
            this.userAccount = userAccount;
        }

        public async Task<bool> IsPremiumUser()
        {
            if (userAccount != null)
            {
                var groups = await userAccount.Value.GetGroups().ToListAsync();
                return groups.Any(g => g.Name == "Premium");
            }

            return false;
        }
        
    }
}

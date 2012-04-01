using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Services;
using OzarkRecovery.Core.Domain.Model;
using System.Web.Security;

namespace OzarkRecovery.Infrastructure.Services
{
    public class SecurityContextService : ISecurityContextService
    {
        public void Create(string username, bool persist = false)
        {
            FormsAuthentication.SetAuthCookie(username, persist);
        }

        public void Destroy(string username)
        {
            FormsAuthentication.SignOut();
        }
    }
}

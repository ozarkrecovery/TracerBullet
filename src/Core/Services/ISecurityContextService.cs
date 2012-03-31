using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Core.Services
{
    public interface ISecurityContextService
    {
        public void Create(string username, bool persist = false);
        public void Destroy(string username);
    }
}

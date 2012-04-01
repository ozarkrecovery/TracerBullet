using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OzarkRecovery.Core.Domain.Model;

namespace OzarkRecovery.Core.Services
{
    public interface ISecurityContextService
    {
        void Create(string username, bool persist = false);
        void Destroy(string username);
    }
}

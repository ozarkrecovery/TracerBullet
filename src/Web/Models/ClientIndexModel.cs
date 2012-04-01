using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OzarkRecovery.Web.Models
{
    public class ClientIndexModel
    {
        public IEnumerable<ClientModel> Clients { get; set; }

        public class ClientModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
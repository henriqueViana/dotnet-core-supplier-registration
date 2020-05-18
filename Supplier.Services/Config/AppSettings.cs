using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierProject.Services.Config
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpireInHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Data_access_lyer.models
{
    public class applicationuser :IdentityUser
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}

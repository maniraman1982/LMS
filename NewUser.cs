using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierServices.Models
{
    public class NewUser
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModfiedDate { get; set; }

        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int cby { get; set; }
        public int mby { get; set; }

        public int appFlag { get; set; }

        public int activeflag { get; set; }

        public int RoleId { get; set; }

        public int DepId { get; set; }


    }
}
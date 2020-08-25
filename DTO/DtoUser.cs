using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DtoUser
    {
        public int userId { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string pasword { get; set; }
        public Nullable<bool> isRegistered { get; set; }
        public Nullable<System.DateTime> dateRegistration { get; set; }
    }
}

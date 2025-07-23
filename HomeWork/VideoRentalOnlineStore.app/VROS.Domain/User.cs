using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain.Enums;

namespace VROS.Domain
{   
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public UserRoles Roles { get; set; }
    }
}

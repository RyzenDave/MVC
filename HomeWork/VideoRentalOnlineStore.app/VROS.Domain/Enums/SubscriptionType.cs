using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.Domain.Enums
{
    public enum SubscriptionType
    {
        [Display(Name = "Free Trial")]
        Free,      // 0
        
        [Display(Name = "Monthly Subscription")]
        Monthly,   // 1
        
        [Display(Name = "Yearly Subscription")]
        Yearly,    // 2
        
        [Display(Name = "Lifetime Membership")]
        Lifetime   // 3
    }
}

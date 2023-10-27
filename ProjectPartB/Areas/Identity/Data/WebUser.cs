using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectPartB.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebUser class
public class WebUser : IdentityUser
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string DrivingLicense { get; set; }
    public string UserID { get; set; }
}



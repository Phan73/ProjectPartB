using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectPartB.Models
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

using ProjectPartB.Areas.Identity.Data;

namespace ProjectPartB.Models
{
    public class EditUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<AspNetRole> Roles { get; set; }


        public virtual AspNetRole Role { get; set; }
        public virtual WebUser User { get; set; } 

        public virtual ICollection<AspNetUser> Users { get; set; } = new HashSet<AspNetUser>();
    }

}

using ProjectPartB.Areas.Identity.Data;

namespace ProjectPartB.Models
{
    public class EditUserRolesViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<UserRoleViewModel> Roles { get; set; }
    }

    public class UserRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }

}

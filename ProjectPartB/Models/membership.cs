using ProjectPartB.Areas.Identity.Data;

namespace ProjectPartB.Models
{
    public class Membership
    {
        //  'Id' is the primary key for Membership and 'UserId' is the foreign key for WebUser.
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


        public string UserId { get; set; }
        public virtual WebUser User { get; set; } // Navigation property for related WebUser

        public virtual ICollection<AspNetUser> Users { get; set; } = new HashSet<AspNetUser>();
    }
}

using ProjectPartB.Areas.Identity.Data;

namespace ProjectPartB.Models
{
    public class Membership
    {
        // Assuming 'Id' is the primary key for Membership and 'UserId' is the foreign key for WebUser.
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        // Keep only one UserId that will serve as a foreign key.
        // Ensure the type of UserId matches the primary key type of WebUser.
        public string UserId { get; set; }
        public virtual WebUser User { get; set; } // Navigation property for related WebUser

        // ICollection for a one-to-many relationship with AspNetUser, if applicable
        // Ensure that this is necessary. If Membership should only be related to one WebUser, you may not need this collection.
        public virtual ICollection<AspNetUser> Users { get; set; } = new HashSet<AspNetUser>();
    }
}

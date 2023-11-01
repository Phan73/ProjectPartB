using ProjectPartB.Areas.Identity.Data;

namespace ProjectPartB.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string UserID { get; set; } 
        public virtual WebUser User { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; } = new HashSet<AspNetUser>();
    }

}

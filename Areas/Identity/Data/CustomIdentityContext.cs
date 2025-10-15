using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPartB.Areas.Identity.Data;
using ProjectPartB.Models;

namespace ProjectPartB.Areas.Identity.Data;

public class CustomIdentityContext : IdentityDbContext<WebUser>
{
    public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options)
        : base(options)
    {
    }
    public DbSet<Membership> Memberships { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       
        base.OnModelCreating(builder);
      
        // Create ROLES
        List<IdentityRole> roles = new List<IdentityRole>() {
          new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
          new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
         new IdentityRole { Name = "Editor", NormalizedName = "EDITOR" },
          new IdentityRole { Name = "Visitor", NormalizedName = "VISITOR" }
          };
        builder.Entity<IdentityRole>().HasData(roles);
         builder.Entity<WebUser>()
        .HasOne(u => u.Membership)                                    
        .WithOne(m => m.User)
        .HasForeignKey<WebUser>(u => u.MembershipId);
        builder.Entity<WebUser>()
    .Property(u => u.UserID)

    .HasDefaultValueSql("NEWID()");
        // Create USERS
        var passwordHasher = new PasswordHasher<WebUser>();
        List<WebUser> users = new List<WebUser>() {
             new WebUser {
                 
                 FullName="Admin",
                 Address="admin",
                 Phone="0210888888",
                 DrivingLicense="fads213",
                 UserName = "administrator@example.com",
                 NormalizedUserName = "ADMINISTRATOR@EXAMPLE.COM",
                 Email = "administrator@example.com",
                 NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                 EmailConfirmed=true,
             },
             new WebUser {

                 

                 FullName="manager",                         

                 Address="manager",
                 Phone="0210888888",
                 DrivingLicense="fads213",
                 UserName = "manager@example.com",
                 NormalizedUserName = "MANAGER@EXAMPLE.COM",
                 Email = "manager@example.com",
                 NormalizedEmail = "MANAGER@EXAMPLE.COM",
                 EmailConfirmed=true
             },
             new WebUser {
                 
                 FullName="editor",
                 Address="editor",
                 Phone="0210888888",
                 DrivingLicense = "fads213",
                 UserName = "editor@example.com",
                 NormalizedUserName = "EDITOR@EXAMPLE.COM",
                 Email = "editor@example.com",
                 NormalizedEmail = "EDITOR@EXAMPLE.COM",
                 EmailConfirmed=true
             },
             new WebUser {
                 
                 FullName="visitor",
                 Address="visitor",
                 Phone="0210888888",
                 DrivingLicense = "fads213",
                 UserName = "visitor@example.com",
                 NormalizedUserName = "VISITOR@EXAMPLE.COM",
                 Email = "visitor@example.com",
                 NormalizedEmail = "VISITOR@EXAMPLE.COM",
                 EmailConfirmed=true
             }
         };
        builder.Entity<WebUser>().HasData(users);

        // Add password to users
        //var passwordHasher = new PasswordHasher<IdentityUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Password@123");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Password@123");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Password@123");
        users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Password@123");

        // Add roles to user
        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[0].Id,
            RoleId = roles.First(q => q.Name == "Administrator").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[1].Id,
            RoleId = roles.First(q => q.Name == "Manager").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[2].Id,
            RoleId = roles.First(q => q.Name == "Editor").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[3].Id,
            RoleId = roles.First(q => q.Name == "Visitor").Id
        });
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}

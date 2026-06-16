using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin"; 
        private const string adminPassword = "Admin_123";

        
        public static async Task IdentityTestUser(IApplicationBuilder app)
        {
          
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();

               
                await context.Database.MigrateAsync();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var user = await userManager.FindByNameAsync(adminUser);

                if (user == null)
                {
                    user = new AppUser
                    {
                        FullName="Sadık Turan",
                        UserName = adminUser,
                        Email = "admin@sadikturan.com",
                        PhoneNumber = "4444444",
                    };
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
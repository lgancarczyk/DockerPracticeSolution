using DockerPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerPractice.Services
{
    public class DatabaseManagementService
    {

        public static void MigrationInit(IApplicationBuilder app) 
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                //serviceScope.ServiceProvider.GetService<AppDBContext>().Database.Migrate();         
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }

        }

        public static void SeedData(AppDBContext context) 
        {
            System.Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();

            if (!context.RecipeModels.Any())
            {
                context.RecipeModels.AddRange(
                    new RecipeModel() { Title = "Pierwsza", Description = " pierwszadesc" },
                    new RecipeModel() { Title = "druga", Description = " drugadesc" }
                    );
                context.SaveChanges();
            }
            else
            {

            }
        }
    }
}

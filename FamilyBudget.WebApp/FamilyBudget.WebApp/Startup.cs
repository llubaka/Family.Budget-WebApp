using Owin;
using Microsoft.Owin;
using System.Data.Entity;

using FamilyBudget.WebApp.Models;
using FamilyBudget.WebApp.Migrations;

[assembly: OwinStartupAttribute(typeof(FamilyBudget.WebApp.Startup))]
namespace FamilyBudget.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}

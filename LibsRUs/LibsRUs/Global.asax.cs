using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace LibsRUs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var configuration = new LibsRUs.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

            //Database.SetInitializer<LibsRUs.DAL.LibsRUsContext>(new MigrateDatabaseToLatestVersion<LibsRUs.DAL.LibsRUsContext, LibsRUs.Migrations.Configuration>());
        }
    }
}

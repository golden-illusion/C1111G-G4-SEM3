namespace Insurance.Migrations
{
    using Insurance.Areas.Admin.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Insurance.Models.InsuranceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Insurance.Models.InsuranceContext context)
        {
            context.Admins.AddOrUpdate<Admin>(
                    p => p.UserName,
                    new Admin { UserName = "Admin", Password = "E10ADC3949BA59ABBE56E057F20F883E" }
                );
        }
    }
}

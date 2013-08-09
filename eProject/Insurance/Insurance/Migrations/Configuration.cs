namespace Insurance.Migrations
{
    using Insurance.Areas.Admin.Models;
    using InSurance.App_Start;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Insurance.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Insurance.Models.InsuranceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Insurance.Models.InsuranceContext context)
        {
            context.Admins.AddOrUpdate<Admin>(
                    p => p.UserName,
                    new Admin { UserName = "Admin", Password = "E10ADC3949BA59ABBE56E057F20F883E" }
                );
            context.Customers.AddOrUpdate<Customer>(
                    c => c.UserName,
                    new Customer
                    {
                        CustomerName = "Mr A",
                        CustomerAddress = "1A Yet Kieu",
                        CustomerPhone = "0123456789",
                        UserName = "MrAA",
                        Vehicles = new List<Vehicle>()
                        {
                            new Vehicle {
                                VehicleId = 1,
                                VehicleName = "Porshe Panamera",
                                VehicleNumber = "29C-1235",
                                VehicleModel = "Sport",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "806364",
                                VehicleEngineNumber = "29K-U-H/11115",
                                VehicleWarranty = true
                            },
                            new Vehicle
                            {
                                VehicleId = 2,
                                VehicleName = "Porsche Cayenne",
                                VehicleNumber = "29C-1236",
                                VehicleModel = "SUV",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "932345",
                                VehicleEngineNumber = "30K-T-Y/33335",
                                VehicleWarranty = false,
                            }
                        }
                    },
                    new Customer
                    {
                        CustomerName = "Mr B",
                        CustomerAddress = "1A Yet Kieu",
                        CustomerPhone = "0123456789",
                        UserName = "MrBB",
                        Vehicles = new List<Vehicle>()
                        {
                            new Vehicle {
                                VehicleId = 3,
                                VehicleName = "BMW 3 Series",
                                VehicleNumber = "29C-1234",
                                VehicleModel = "Sedan",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "9973245",
                                VehicleEngineNumber = "31K-U-K/123456",
                                VehicleWarranty = true
                            },
                            new Vehicle
                            {
                                VehicleId = 4,
                                VehicleName = "Mercedes E250",
                                VehicleNumber = "29D-1234",
                                VehicleModel = "Sedan",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "9973245",
                                VehicleEngineNumber = "31K-U-K/123456",
                                VehicleWarranty = false,
                            }
                        }
                    },
                    new Customer
                    {
                        CustomerName = "Mr C",
                        CustomerAddress = "1A Yet Kieu",
                        CustomerPhone = "0123456789",
                        UserName = "MrCC",
                        Vehicles = new List<Vehicle>()
                        {
                            new Vehicle {
                                VehicleId = 5,
                                VehicleName = "Toyota Camry",
                                VehicleNumber = "30C-4434",
                                VehicleModel = "Sedan",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "9973245",
                                VehicleEngineNumber = "31K-U-K/123456",
                                VehicleWarranty = true
                            },
                            new Vehicle
                            {
                                VehicleId = 6,
                                VehicleName = "Mercedes E250",
                                VehicleNumber = "99C-1234",
                                VehicleModel = "Sedan",
                                VehicleVersion = 2013,
                                VehicleBodyNumber = "9973245",
                                VehicleEngineNumber = "31K-U-K/123456",
                                VehicleWarranty = false,
                            }
                        }
                    }
                );
            context.Policies.AddOrUpdate<Policy>(
                p => p.PolicyType,
                new Policy
                {
                    PolicyId = 1,
                    PolicyType = "Liability Insurance",
                    PolicyDuration = 365,
                    Description = "Liability insurance covers you in the event you are in a covered car accident and it is determined the accident is a result of your actions.",
                    PolicyPrice = 100
                },
                new Policy
                {
                    PolicyId = 2,
                    PolicyType = "Collision Coverage",
                    PolicyDuration = 365,
                    Description = "If there is a covered accident, collision coverage will pay for the repairs to your car.",
                    PolicyPrice = 200
                },
                new Policy
                {
                    PolicyId = 3,
                    PolicyType = "Comprehensive Coverage",
                    PolicyDuration = 365,
                    Description = "What if something happens to your car that is unrelated to a covered accident - weather damage, you hit a deer, your car is stolen - will your insurance company cover the loss?",
                    PolicyPrice = 350
                },
                new Policy
                {
                    PolicyId = 4,
                    PolicyType = "Personal Injury Protection",
                    PolicyDuration = 365,
                    Description = "While Comprehensive coverage may be something you don’t need to purchase, Personal Injury Protection (PIP) is something you should.",
                    PolicyPrice = 250
                },
                new Policy
                {
                    PolicyId = 5,
                    PolicyType = "Uninsured /Underinsured Motorist Protection",
                    PolicyDuration = 365,
                    Description = "While state laws mandate that all drivers should be insured, this is unfortunately not always the case.",
                    PolicyPrice = 150
                }
            );
            WebSecurityConfig.RegisterWebSecurity();
        }
    }
}

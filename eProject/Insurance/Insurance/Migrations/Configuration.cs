namespace Insurance.Migrations
{
    using Insurance.Areas.Admin.Models;
    using Insurance.Models;
    using InSurance.App_Start;
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
            context.Admins.AddOrUpdate<Admin>
                (
                    p => p.UserName,
                    new Admin { UserName = "Admin", Password = "E10ADC3949BA59ABBE56E057F20F883E" }
                );

            context.Customers.AddOrUpdate<Customer>
                (
                        new Customer 
                        {
                            UserName = "NHATDT",
                            CustomerName = "Dang Thanh Nhat",
                            CustomerAddress = "Ha Noi",
                            CustomerPhone = "01669098040"
                        },

                        new Customer
                        {
                            UserName = "VIENNV",
                            CustomerName = "Nguyen Van Vien",
                            CustomerAddress = "Ha Noi",
                            CustomerPhone = "01234567899"
                        },

                        new Customer
                        {
                            UserName = "HIEUDH",
                            CustomerName = "Dang Hoang Hieu",
                            CustomerAddress = "Ha Noi",
                            CustomerPhone = "8982376495"
                        },

                        new Customer
                        {
                            UserName = "TANPD",
                            CustomerName = "Pham Dinh Tan",
                            CustomerAddress = "Ha Noi",
                            CustomerPhone = "928312934"
                        },

                        new Customer
                        {
                            UserName = "HIEPV",
                            CustomerName = "Vu Hiep",
                            CustomerAddress = "Ha Noi",
                            CustomerPhone = "42342234"
                        }
                );

            context.Vehicles.AddOrUpdate<Vehicle>(
                        new Vehicle
                        {
                            VehicleName = "Porshe Panamera",
                            VehicleModel = "Sport",
                            VehicleVersion = 2013,
                            VehicleRate = 9,
                            VehicleBodyNumber = "806364",
                            VehicleEngineNumber = "29K-U-H/11115",
                            VehicleWarranty = "3 Years",
                        },

                        new Vehicle
                        {
                            VehicleName = "Porsche Cayenne",
                            VehicleModel = "SUV",
                            VehicleVersion = 2013,
                            VehicleRate = 8.5,
                            VehicleBodyNumber = "932345",
                            VehicleEngineNumber = "30K-T-Y/33335",
                            VehicleWarranty = "3 Years",
                        },

                        new Vehicle
                        {
                            VehicleName = "BMW 3 Series",
                            VehicleModel = "Sedan",
                            VehicleVersion = 2013,
                            VehicleRate = 8,
                            VehicleBodyNumber = "9973245",
                            VehicleEngineNumber = "31K-U-K/123456",
                            VehicleWarranty = "3 Years",
                        },

                        new Vehicle
                        {
                            VehicleName = "Mercedes E250",
                            VehicleModel = "Sedan",
                            VehicleVersion = 2013,
                            VehicleRate = 8,
                            VehicleBodyNumber = "632454",
                            VehicleEngineNumber = "29C-J-D/873845",
                            VehicleWarranty = "3 Years",
                        },

                        new Vehicle
                        {
                            VehicleName = "Toyota Camry",
                            VehicleModel = "Sedan",
                            VehicleVersion = 2012,
                            VehicleRate = 7,
                            VehicleBodyNumber = "323457",
                            VehicleEngineNumber = "56I-T-C/667235",
                            VehicleWarranty = "3 Years",
                        }
                );
            context.CustomerPolicies.AddOrUpdate<CustomerPolicy>
                (
                        new CustomerPolicy 
                        {
                            StartDate = DateTime.Parse("2013-08-05"),
                            EndDate = DateTime.Parse("2013-12-12")
                        },

                        new CustomerPolicy 
                        {
                            StartDate = DateTime.Parse("2013-08-06"),
                            EndDate = DateTime.Parse("2013-12-13")
                        },

                        new CustomerPolicy 
                        {
                            StartDate = DateTime.Parse("2013-08-07"),
                            EndDate = DateTime.Parse("2013-12-14")
                        },

                        new CustomerPolicy 
                        {
                            StartDate = DateTime.Parse("2013-08-08"),
                            EndDate = DateTime.Parse("2013-12-15")
                        },

                        new CustomerPolicy 
                        {
                            StartDate = DateTime.Parse("2013-08-09"),
                            EndDate = DateTime.Parse("2013-12-16")
                        }
                );

            context.Claims.AddOrUpdate<Claim>
                (
                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-05"),
                        InsuredAmount = 4567,
                        ClaimableAmount = 1234,
                    },
                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-06"),
                        InsuredAmount = 4587,
                        ClaimableAmount = 2131 ,
                    },

                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-07"),
                        InsuredAmount = 4325,
                        ClaimableAmount = 1234,
                    },

                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-08"),
                        InsuredAmount = 4567,
                        ClaimableAmount = 4123,
                    },

                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-09"),
                        InsuredAmount = 2134,
                        ClaimableAmount = 2134,
                    },

                    new Claim
                    {
                        AccidentPlace = "Ha Noi",
                        AccidentDate = DateTime.Parse("2013-08-05"),
                        InsuredAmount = 4123,
                        ClaimableAmount = 1144,
                    }
                );

            context.Expenses.AddOrUpdate<Expense>
                (
                    new Expense 
                    {
                        ExpenseType = "Cash",
                        ExpenseDate = DateTime.Parse("2013-08-06"),
                        ExpenseAmount = 1234
                    },

                    new Expense 
                    {
                        ExpenseType = "Cash",
                        ExpenseDate = DateTime.Parse("2013-08-16"),
                        ExpenseAmount = 4234
                    },

                    new Expense 
                    {
                        ExpenseType = "Cash",
                        ExpenseDate = DateTime.Parse("2013-09-06"),
                        ExpenseAmount = 5435
                    },

                    new Expense 
                    {
                        ExpenseType = "Cash",
                        ExpenseDate = DateTime.Parse("2013-02-21"),
                        ExpenseAmount = 2344
                    },

                    new Expense 
                    {
                        ExpenseType = "Cash",
                        ExpenseDate = DateTime.Parse("2013-12-08"),
                        ExpenseAmount = 6789
                    }
                );

            context.Policies.AddOrUpdate<Policy>
                (
                    new Policy 
                    {
                        PolicyType = "Third Party Only",
                        PolicyDuration = 12,
                        PolicyPrice = 200000
                    },

                    new Policy 
                    {
                        PolicyType = "Third Party Fire and Theft",
                        PolicyDuration = 24,
                        PolicyPrice = 300000
                    },

                    new Policy 
                    {
                        PolicyType = "Comprehensive",
                        PolicyDuration = 36,
                        PolicyPrice = 500000
                    }
                );

            context.Testimonials.AddOrUpdate<Testimonial>
                (
                    new Testimonial
                    {
                        Content = "abcdef",
                        TestimonialDate = DateTime.Parse("2013-12-08")
                    },

                    new Testimonial
                    {
                        Content = "qwerty",
                        TestimonialDate = DateTime.Parse("2013-12-08")
                    }
                );

                   

                
            WebSecurityConfig.RegisterWebSecurity();
        }
    }
}

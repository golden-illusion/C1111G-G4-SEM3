namespace Insurance.Migrations
{
    using Insurance.Areas.Admin.Models;
    using Insurance.Models;
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
<<<<<<< HEAD
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
=======

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

                   

                
>>>>>>> 01f425f57fce98f25b360538213a9436efc4151c
            WebSecurityConfig.RegisterWebSecurity();
        }
    }
}

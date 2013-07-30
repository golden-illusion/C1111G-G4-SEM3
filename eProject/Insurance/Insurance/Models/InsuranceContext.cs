using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Insurance.Areas.Admin.Models;

namespace Insurance.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CompanyExpense> CompanyExpenses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
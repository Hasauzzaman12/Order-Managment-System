using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Data Models
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CsPerson> CsPersons { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<UoM> UoMs { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MainMenu> MainMenus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
        //    {
        //        item.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    modelBuilder.Entity<Company>().HasData(
        //    new Company
        //    {
        //        CompanyId = 1,
        //        CompanyName = "Test Company",
        //        Address = "Dhaka",
        //        Email = "Test@gmail.com",
        //        ContactPerson = "Shuvo",
        //        Mobile = "01730057389",
        //        IsActive = true,
        //    }
        //   );

        //    modelBuilder.Entity<IdentityRole>().HasData(
        //    new IdentityRole
        //    {
        //        Id = "2ca6ebce-3bb2-4e38-80ef-4d731176602e",
        //        Name = "Admin",
        //        NormalizedName= "Admin",
        //    }
        //   );

        //}



        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new())
        {
            //var userId = _context.HttpContext.Session.GetInt32("UserId");

            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    case EntityState.Added when entry.Entity is BaseModel:
                        //entry.Property(nameof(BaseModel.UpdatedBy)).IsModified = false;
                        entry.Property(nameof(BaseModel.ModifiedDate)).IsModified = false;
                        //entry.Property(nameof(BaseModel.CreatedBy)).CurrentValue = userId;
                        entry.Property(nameof(BaseModel.CreatedDate)).CurrentValue = DateTime.Now;
                        break;

                    case EntityState.Modified when entry.Entity is BaseModel:
                        //entry.Property(nameof(BaseModel.CreatedBy)).IsModified = false;
                        entry.Property(nameof(BaseModel.CreatedDate)).IsModified = false;
                        //entry.Property(nameof(BaseModel.UpdatedBy)).CurrentValue = userId;
                        entry.Property(nameof(BaseModel.ModifiedDate)).CurrentValue = DateTime.Now;
                        break;
                }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}

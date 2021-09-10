using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace phamarchy_systeam.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Phamarcy_adress> Phamarcy_adress { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier_details> Supplier_details { get; set; }
        public virtual DbSet<User_details> User_details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_details)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order1)
                .WithOptional(e => e.Order2)
                .HasForeignKey(e => e.Order_FID_Return);

            modelBuilder.Entity<Product>()
                .Property(e => e.Product_discount)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_details)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Product_fid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier_details>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Supplier_details)
                .HasForeignKey(e => e.Supplier_fid);

            modelBuilder.Entity<User_details>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User_details)
                .HasForeignKey(e => e.User_fid);
        }
    }
}

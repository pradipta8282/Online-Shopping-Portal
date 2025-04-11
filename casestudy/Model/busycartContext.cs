using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace casestudy.Model
{
    public partial class busycartContext : DbContext
    {
        public busycartContext()
        {
        }

        public busycartContext(DbContextOptions<busycartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customerinfo> Customerinfos { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DotNetFSD\\SQLEXPRESS;Database=busycart;User ID=sa;Password=pass@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");

                entity.Property(e => e.Branchid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("branchid");

                entity.Property(e => e.Branchname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchname");

                entity.Property(e => e.Cityid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cityid");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK__branch__cityid__2DE6D218");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__cart__D837D05FFD2A447C");

                entity.ToTable("cart");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Customerid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerid");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__cart__customerid__47A6A41B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK__cart__productid__489AC854");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatgId)
                    .HasName("PK__category__DC199F4D5E1C008C");

                entity.ToTable("category");

                entity.Property(e => e.CatgId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("catg_id");

                entity.Property(e => e.CatgName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("catg_name");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Cityid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cityid");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cityname");

                entity.Property(e => e.Countryid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("countryid");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__city__countryid__2B0A656D");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Countryid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("countryid");

                entity.Property(e => e.Countryname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("countryname");
            });

            modelBuilder.Entity<Customerinfo>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__customer__973AFEFE4B71EB5C");

                entity.ToTable("customerinfo");

                entity.Property(e => e.Custid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("custid");

                entity.Property(e => e.Contactno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contactno");

                entity.Property(e => e.Custcity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("custcity");

                entity.Property(e => e.Custemail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("custemail");

                entity.Property(e => e.Custname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("custname");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Customerid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerid");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailid");

                entity.Property(e => e.Orderamnt).HasColumnName("orderamnt");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Orderstat).HasColumnName("orderstat");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__orders__customer__44CA3770");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.Paymentid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("paymentid");

                entity.Property(e => e.Customerid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerid");

                entity.Property(e => e.Paymentdate)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("paymentdate");

                entity.Property(e => e.Penalty)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("penalty");

                entity.Property(e => e.Transactionid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("transactionid");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK__payments__custom__3D2915A8");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Transactionid)
                    .HasConstraintName("FK__payments__transa__3C34F16F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Productid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("productid");

                entity.Property(e => e.Categoryid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("categoryid");

                entity.Property(e => e.Productname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Productprice).HasColumnName("productprice");

                entity.Property(e => e.Producturl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("producturl");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__products__catego__32AB8735");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.Transactionid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("transactionid");

                entity.Property(e => e.Branchid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("branchid");

                entity.Property(e => e.Custid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("custid");

                entity.Property(e => e.Productid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productname");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Transdate)
                    .HasColumnType("date")
                    .HasColumnName("transdate");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Branchid)
                    .HasConstraintName("FK__transacti__branc__395884C4");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("FK__transacti__custi__37703C52");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK__transacti__produ__3864608B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

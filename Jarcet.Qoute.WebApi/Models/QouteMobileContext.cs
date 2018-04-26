using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Microsoft.Azure.Mobile.Server.Tables;

namespace Jarcet.Qoutes.WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QouteMobileContext : DbContext
    {
        public static QouteMobileContext Create()
        {
            return new QouteMobileContext();
        }
        public QouteMobileContext()
            : base("name=QouteEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Database.Log = s => { Debug.WriteLine(s); };
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<QouteDetails> QouteDetails { get; set; }
        public virtual DbSet<Qoutes> Qoutes { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
            modelBuilder.Entity<Categories>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Qoutes)
                .WithOptional(e => e.Clients)
                .HasForeignKey(e => e.ClientId);

            modelBuilder.Entity<Products>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.QouteDetails)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<Qoutes>()
                .Property(e => e.Version)
                .IsFixedLength();

            modelBuilder.Entity<Qoutes>()
                .HasMany(e => e.QouteDetails)
                .WithOptional(e => e.Qoutes)
                .HasForeignKey(e => e.QouteId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<UserRoles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.UserRoles)
                .Map(m => m.ToTable("UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<Users>()
                .Property(e => e.Height)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Users>()
                .Property(e => e.Weight)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Qoutes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserClaims)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }

        
    }
}

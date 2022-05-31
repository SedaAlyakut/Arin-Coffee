using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramwork
{
    public partial class ArinCoffeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyData"), o => o.CommandTimeout(9999999));

        }

        public  DbSet<Card> Cards { get; set; }
        public  DbSet<Comment> Comments { get; set; }
        public  DbSet<FeedBack> FeedBacks { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<Watch> Watches { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ageofcats_ArinCoffee");

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Product");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Rewiew).HasColumnType("text");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Topic).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "dbo");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.EndTime).HasColumnType("date");

                entity.Property(e => e.OrderTime).HasColumnType("date");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Card");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "dbo");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Image1).IsUnicode(false);

                entity.Property(e => e.Image2).IsUnicode(false);

                entity.Property(e => e.Image3).IsUnicode(false);

                entity.Property(e => e.Image4).IsUnicode(false);

                entity.Property(e => e.Image5).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK_USERS");

                entity.ToTable("Users", "dbo");

                entity.Property(e => e.UsersId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsersID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Watch>(entity =>
            {
                entity.ToTable("Watch", "dbo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Watches)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Watch_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

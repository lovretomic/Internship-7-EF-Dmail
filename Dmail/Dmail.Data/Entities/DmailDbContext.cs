using Dmail.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dmail.Data.Seeds;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dmail.Data.Entities
{
    public class DmailDbContext : DbContext
    {
        public DmailDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<UserItem> UserItems => Set<UserItem>();
        public DbSet<SpamAdress> SpamAdresses => Set<SpamAdress>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserItem>()
                .HasKey(ue => new { ue.UserId, ue.ItemId });

            modelBuilder.Entity<UserItem>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserItems)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<UserItem>()
                .HasOne(g => g.Item)
                .WithMany(u => u.UserItems)
                .HasForeignKey(gu => gu.ItemId);


            modelBuilder.Entity<SpamAdress>()
                .HasKey(sa => new { sa.User1Id, sa.User2Id });

            modelBuilder.Entity<SpamAdress>()
                .HasOne(sa => sa.User1)
                .WithMany(u => u.SpamAdresses1)
                .HasForeignKey(sa => sa.User1Id);

            modelBuilder.Entity<SpamAdress>()
                .HasOne(sa => sa.User2)
                .WithMany(u => u.SpamAdresses2)
                .HasForeignKey(sa => sa.User2Id);

            InitialSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<DmailDbContext>
    {
        public DmailDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:DmailDb:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<DmailDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DmailDbContext(options);
        }
    }
}

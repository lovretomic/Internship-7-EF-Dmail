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

        //public DbSet<Event> Events => Set<Event>();
        //public DbSet<Message> Messages => Set<Message>();
        public DbSet<User> Users => Set<User>();
        //public DbSet<UserEvent> UserEvents => Set<UserEvent>();
        //public DbSet<UserMessage> UserMessages => Set<UserMessage>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<UserItem> UserItems => Set<UserItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<UserEvent>()
                .HasKey(ue => new { ue.UserId, ue.EventId });

            modelBuilder.Entity<UserEvent>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<UserEvent>()
                .HasOne(g => g.Event)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(gu => gu.EventId);

            modelBuilder.Entity<UserMessage>()
                .HasKey(um => new { um.UserId, um.MessageId });

            modelBuilder.Entity<UserMessage>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<UserMessage>()
                .HasOne(g => g.Message)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(gu => gu.MessageId);
            */

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

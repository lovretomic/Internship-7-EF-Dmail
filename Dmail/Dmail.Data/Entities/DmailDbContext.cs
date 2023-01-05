using Dmail.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dmail.Data.Entities
{
    public class DmailDbContext : DbContext
    {
        public DmailDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserEvent> UserEvents => Set<UserEvent>();
        public DbSet<UserMessage> UserMessages => Set<UserMessage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEvent>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<UserEvent>()
                .HasOne(g => g.Event)
                .WithMany(u => u.UserEvents)
                .HasForeignKey(gu => gu.EventId);

            modelBuilder.Entity<UserMessage>()
                .HasOne(g => g.User)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<UserMessage>()
                .HasOne(g => g.Message)
                .WithMany(u => u.UserMessages)
                .HasForeignKey(gu => gu.MessageId);
        }
    }
}

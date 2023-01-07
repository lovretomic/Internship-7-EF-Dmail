﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dmail.Data.Migrations
{
    [DbContext(typeof(DmailDbContext))]
    partial class DmailDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dmail.Data.Entities.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<int>>("Receivers")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("SentOn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.",
                            SenderId = 3,
                            SentOn = "2023-01-06",
                            Title = "Mail1"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.",
                            SenderId = 3,
                            SentOn = "2023-01-05",
                            Title = "Mail2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris, non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a. Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat nisi eu libero commodo, a.",
                            SenderId = 3,
                            SentOn = "2023-01-04",
                            Title = "Mail3"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jadrankalovric@gmail.com",
                            FirstName = "Jadranka",
                            LastName = "Lovrić",
                            Password = "QJpzGc94Vf7P"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mate.jerkovic@gmail.com",
                            FirstName = "Mate",
                            LastName = "Jerković",
                            Password = "4K3fgnoj7T3V"
                        },
                        new
                        {
                            Id = 3,
                            Email = "hercegdragoslav@gmail.com",
                            FirstName = "Dragoslav",
                            LastName = "Herceg",
                            Password = "QsoCrT4CqErv"
                        },
                        new
                        {
                            Id = 4,
                            Email = "vukojaranka90@hotmail.com",
                            FirstName = "Ranka",
                            LastName = "Vukoja",
                            Password = "y45LRkBQjtmg"
                        },
                        new
                        {
                            Id = 5,
                            Email = "helenaknez@gmail.com",
                            FirstName = "Helena",
                            LastName = "Knežević",
                            Password = "P5LWdm9sDPnc"
                        },
                        new
                        {
                            Id = 6,
                            Email = "stipel@gmail.com",
                            FirstName = "Stjepan",
                            LastName = "Lučić",
                            Password = "bBQ3mEVXFEHc"
                        },
                        new
                        {
                            Id = 7,
                            Email = "visnja.pavlovic@gmail.com",
                            FirstName = "Višnja",
                            LastName = "Pavlović",
                            Password = "8u8sBshThMnK"
                        },
                        new
                        {
                            Id = 8,
                            Email = "alenkosar1@gmail.com",
                            FirstName = "Alen",
                            LastName = "Košar",
                            Password = "G2TJfh1BgjJo"
                        },
                        new
                        {
                            Id = 9,
                            Email = "nikolic.p@gmail.com",
                            FirstName = "Pero",
                            LastName = "Nikolić",
                            Password = "0nUda4jTo7Ar"
                        },
                        new
                        {
                            Id = 10,
                            Email = "jankojuric99@yahoo.com",
                            FirstName = "Janko",
                            LastName = "Jurić",
                            Password = "vugpkNAzkp6G"
                        },
                        new
                        {
                            Id = 11,
                            Email = "domagoj.jerko@gmail.com",
                            FirstName = "Domagoj",
                            LastName = "Jerković",
                            Password = "b3VigXxiQJkR"
                        },
                        new
                        {
                            Id = 12,
                            Email = "lucicantonela@gmail.com",
                            FirstName = "Antonela",
                            LastName = "Lučić",
                            Password = "WZv4zYpAVszQ"
                        },
                        new
                        {
                            Id = 13,
                            Email = "adam.ivanovic2@gmail.com",
                            FirstName = "Adam",
                            LastName = "Ivanović",
                            Password = "BvHVg4EyWja6"
                        },
                        new
                        {
                            Id = 14,
                            Email = "brunopavicic@gmail.com",
                            FirstName = "Bruno",
                            LastName = "Pavičić",
                            Password = "3jiW5m92eFsb"
                        },
                        new
                        {
                            Id = 15,
                            Email = "perko.anja09@gmail.com",
                            FirstName = "Anja",
                            LastName = "Perko",
                            Password = "qkipaEkfPi2P"
                        },
                        new
                        {
                            Id = 16,
                            Email = "tomiclovre05@gmail.com",
                            FirstName = "Lovre",
                            LastName = "Tomić",
                            Password = "pass123"
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.UserEvent", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvents");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.UserMessage", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("MessageId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("UserMessages");

                    b.HasData(
                        new
                        {
                            UserId = 16,
                            MessageId = 1,
                            Status = 0
                        },
                        new
                        {
                            UserId = 16,
                            MessageId = 2,
                            Status = 0
                        },
                        new
                        {
                            UserId = 16,
                            MessageId = 3,
                            Status = 0
                        },
                        new
                        {
                            UserId = 14,
                            MessageId = 1,
                            Status = 0
                        },
                        new
                        {
                            UserId = 11,
                            MessageId = 2,
                            Status = 0
                        });
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.UserEvent", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.UserMessage", b =>
                {
                    b.HasOne("Dmail.Data.Entities.Models.Message", "Message")
                        .WithMany("UserMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dmail.Data.Entities.Models.User", "User")
                        .WithMany("UserMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Event", b =>
                {
                    b.Navigation("UserEvents");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.Message", b =>
                {
                    b.Navigation("UserMessages");
                });

            modelBuilder.Entity("Dmail.Data.Entities.Models.User", b =>
                {
                    b.Navigation("UserEvents");

                    b.Navigation("UserMessages");
                });
#pragma warning restore 612, 618
        }
    }
}

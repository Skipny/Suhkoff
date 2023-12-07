﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Suhkoff.Data;

#nullable disable

namespace Suhkoff.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231207075711_fix db")]
    partial class fixdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Suhkoff.Data.tasks", b =>
                {
                    b.Property<int>("task_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("task_description")
                        .HasColumnType("longtext");

                    b.Property<string>("task_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("task_status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("task_id");

                    b.HasIndex("user_id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Suhkoff.Data.users", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Suhkoff.Data.tasks", b =>
                {
                    b.HasOne("Suhkoff.Data.users", "users")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}

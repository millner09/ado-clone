﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthProviderId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkItemStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkItemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemStateId");

                    b.HasIndex("WorkItemTypeId");

                    b.ToTable("WorkItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a843d8fa-07f2-41ce-bf7b-95e2d832585a"),
                            Title = "Seed User Story in Database",
                            WorkItemStateId = new Guid("d0b1d039-42c8-4686-bb9d-217ea591acbc"),
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        });
                });

            modelBuilder.Entity("Domain.WorkItemState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkItemBaseState")
                        .HasColumnType("int");

                    b.Property<Guid>("WorkItemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemTypeId");

                    b.ToTable("WorkItemStates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0b1d039-42c8-4686-bb9d-217ea591acbc"),
                            Name = "New",
                            WorkItemBaseState = 0,
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        },
                        new
                        {
                            Id = new Guid("72ad6b05-eebd-4f8d-8b51-34902a77e754"),
                            Name = "Active",
                            WorkItemBaseState = 1,
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        },
                        new
                        {
                            Id = new Guid("5e77b602-d769-41e9-85e6-91da32284057"),
                            Name = "Resolved",
                            WorkItemBaseState = 1,
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        },
                        new
                        {
                            Id = new Guid("6ade6878-0311-4454-8cc8-4ab2afc1582b"),
                            Name = "Closed",
                            WorkItemBaseState = 2,
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        },
                        new
                        {
                            Id = new Guid("250b3eb8-1100-454b-8ca5-dd840b45d354"),
                            Name = "Removed",
                            WorkItemBaseState = 3,
                            WorkItemTypeId = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84")
                        });
                });

            modelBuilder.Entity("Domain.WorkItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkItemTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84"),
                            Name = "User Story"
                        });
                });

            modelBuilder.Entity("Domain.WorkItem", b =>
                {
                    b.HasOne("Domain.WorkItemState", "WorkItemState")
                        .WithMany()
                        .HasForeignKey("WorkItemStateId");

                    b.HasOne("Domain.WorkItemType", "WorkItemType")
                        .WithMany()
                        .HasForeignKey("WorkItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkItemState");

                    b.Navigation("WorkItemType");
                });

            modelBuilder.Entity("Domain.WorkItemState", b =>
                {
                    b.HasOne("Domain.WorkItemType", "WorkItemType")
                        .WithMany("AvailableWorkItemStates")
                        .HasForeignKey("WorkItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkItemType");
                });

            modelBuilder.Entity("Domain.WorkItemType", b =>
                {
                    b.Navigation("AvailableWorkItemStates");
                });
#pragma warning restore 612, 618
        }
    }
}

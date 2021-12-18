﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scout.Infrastructure.EF.Contexts;

#nullable disable

namespace Scout.Infrastructure.EF.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20211218123543_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scout.Domain.ObjectOwners.Entities.ObjectOwner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ScoutObjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("_companyName")
                        .HasColumnType("text")
                        .HasColumnName("CompanyName");

                    b.Property<string>("_urlSite")
                        .HasColumnType("text")
                        .HasColumnName("UrlSite");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ScoutObjectId");

                    b.ToTable("ObjectOwner");
                });

            modelBuilder.Entity("Scout.Domain.Persons.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("_email")
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("_firstName")
                        .HasColumnType("text")
                        .HasColumnName("FirstName");

                    b.Property<string>("_lastName")
                        .HasColumnType("text")
                        .HasColumnName("LastName");

                    b.Property<string>("_phoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Scout.Domain.ScoutObjects.Entities.ScoutObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<string>("_name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<short>("_objectStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("ObjectStatus");

                    b.Property<short>("_objectType")
                        .HasColumnType("smallint")
                        .HasColumnName("ObjectType");

                    b.HasKey("Id");

                    b.ToTable("ScoutObjects");
                });

            modelBuilder.Entity("Scout.Domain.ObjectOwners.Entities.ObjectOwner", b =>
                {
                    b.HasOne("Scout.Domain.Persons.Entities.Person", "_person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Scout.Domain.ScoutObjects.Entities.ScoutObject", "_scoutObject")
                        .WithMany()
                        .HasForeignKey("ScoutObjectId");

                    b.OwnsOne("Scout.Domain.ValueObjects.Address", "_address", b1 =>
                        {
                            b1.Property<long>("ObjectOwnerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("PlotNumber")
                                .HasColumnType("text")
                                .HasColumnName("PlotNumber");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("text")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("ObjectOwnerId");

                            b1.ToTable("ObjectOwner");

                            b1.WithOwner()
                                .HasForeignKey("ObjectOwnerId");
                        });

                    b.Navigation("_address");

                    b.Navigation("_person");

                    b.Navigation("_scoutObject");
                });

            modelBuilder.Entity("Scout.Domain.ScoutObjects.Entities.ScoutObject", b =>
                {
                    b.OwnsOne("Scout.Domain.ValueObjects.Address", "_address", b1 =>
                        {
                            b1.Property<long>("ScoutObjectId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("PlotNumber")
                                .HasColumnType("text")
                                .HasColumnName("PlotNumber");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("text")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("Street")
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.HasKey("ScoutObjectId");

                            b1.ToTable("ScoutObjects");

                            b1.WithOwner()
                                .HasForeignKey("ScoutObjectId");
                        });

                    b.Navigation("_address");
                });
#pragma warning restore 612, 618
        }
    }
}

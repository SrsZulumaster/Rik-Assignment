﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rik_Assignment.Data;

#nullable disable

namespace Rik_Assignment.Migrations
{
    [DbContext(typeof(Rik_AssignmentContext))]
    partial class Rik_AssignmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.CompanyParticipantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyID")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventRefID")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantAmount")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventRefID");

                    b.ToTable("CompanyParticipantModel");
                });

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.EventModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventModel");
                });

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.ParticipantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int?>("EventRefID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalID")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("EventRefID");

                    b.ToTable("ParticipantModel");
                });

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.CompanyParticipantModel", b =>
                {
                    b.HasOne("Rik_Assignment.Pages.ViewModel.EventModel", "EventModel")
                        .WithMany("Company")
                        .HasForeignKey("EventRefID");

                    b.Navigation("EventModel");
                });

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.ParticipantModel", b =>
                {
                    b.HasOne("Rik_Assignment.Pages.ViewModel.EventModel", "EventModel")
                        .WithMany("Participant")
                        .HasForeignKey("EventRefID");

                    b.Navigation("EventModel");
                });

            modelBuilder.Entity("Rik_Assignment.Pages.ViewModel.EventModel", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("Participant");
                });
#pragma warning restore 612, 618
        }
    }
}

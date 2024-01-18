﻿// <auto-generated />
using System;
using AirlineTicketsReservation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineTicketsReservation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240118162952_DataeKthimitMigrim")]
    partial class DataeKthimitMigrim
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineTicketsReservation.Models.Aeroplani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kompania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nr_Uleseve_Biznes")
                        .HasColumnType("int");

                    b.Property<int>("Nr_Uleseve_Ekonomike")
                        .HasColumnType("int");

                    b.Property<int>("Nr_Uleseve_VIP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aeroplani");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Fluturimi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AeroplaniId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cmimi")
                        .HasColumnType("int");

                    b.Property<string>("DeparuteAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KohaEArritjes")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KohaENisjes")
                        .HasColumnType("datetime2");

                    b.Property<string>("NrFluturimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QytetiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AeroplaniId");

                    b.HasIndex("QytetiId");

                    b.ToTable("Fluturimet");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Kontakti", b =>
                {
                    b.Property<int>("KontaktID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KontaktID"));

                    b.Property<string>("Emaili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesazhi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumriTelefonit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontaktID");

                    b.ToTable("Kontakti");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Perdoruesi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perdoruesit");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Qyteti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Emri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShtetiId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShtetiId");

                    b.ToTable("Qyteti");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Rezervimi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Cmimi")
                        .HasColumnType("bigint");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Data_e_Kthimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("Data_e_Rezervimit")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmriPasagjerit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FluturimiId")
                        .HasColumnType("int");

                    b.Property<string>("Klasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Kthyese")
                        .HasColumnType("bit");

                    b.Property<string>("MbiemriPasagjerit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FluturimiId");

                    b.ToTable("Rezervimet");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Shteti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Emri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shteti");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Fluturimi", b =>
                {
                    b.HasOne("AirlineTicketsReservation.Models.Aeroplani", "Aeroplani")
                        .WithMany()
                        .HasForeignKey("AeroplaniId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirlineTicketsReservation.Models.Qyteti", "Qyteti")
                        .WithMany()
                        .HasForeignKey("QytetiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aeroplani");

                    b.Navigation("Qyteti");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Qyteti", b =>
                {
                    b.HasOne("AirlineTicketsReservation.Models.Shteti", "Shteti")
                        .WithMany()
                        .HasForeignKey("ShtetiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shteti");
                });

            modelBuilder.Entity("AirlineTicketsReservation.Models.Rezervimi", b =>
                {
                    b.HasOne("AirlineTicketsReservation.Models.Fluturimi", "Fluturimi")
                        .WithMany()
                        .HasForeignKey("FluturimiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fluturimi");
                });
#pragma warning restore 612, 618
        }
    }
}

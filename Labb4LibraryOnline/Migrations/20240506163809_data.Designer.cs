﻿// <auto-generated />
using System;
using Labb4LibraryOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4LibraryOnline.Migrations
{
    [DbContext(typeof(LibraryOnlineDbContext))]
    [Migration("20240506163809_data")]
    partial class data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb4LibraryOnline.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookGenre")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Labb4LibraryOnline.Models.BookLoan", b =>
                {
                    b.Property<int>("BookLoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookLoanId"));

                    b.Property<DateTime>("BookLoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FkBookId")
                        .HasColumnType("int");

                    b.Property<int>("FkCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("BookLoanId");

                    b.HasIndex("FkBookId");

                    b.HasIndex("FkCustomerId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Labb4LibraryOnline.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerAdress")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CustomerMail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("FavGenre")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Labb4LibraryOnline.Models.BookLoan", b =>
                {
                    b.HasOne("Labb4LibraryOnline.Models.Book", "Book")
                        .WithMany("BookLoans")
                        .HasForeignKey("FkBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb4LibraryOnline.Models.Customer", "Customer")
                        .WithMany("BookLoans")
                        .HasForeignKey("FkCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Labb4LibraryOnline.Models.Book", b =>
                {
                    b.Navigation("BookLoans");
                });

            modelBuilder.Entity("Labb4LibraryOnline.Models.Customer", b =>
                {
                    b.Navigation("BookLoans");
                });
#pragma warning restore 612, 618
        }
    }
}

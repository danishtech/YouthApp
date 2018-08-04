﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouthApp.Context;

namespace YouthApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180803162551_TransStudent")]
    partial class TransStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("YouthApp.Context.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("YouthApp.Models.BillItems", b =>
                {
                    b.Property<int>("BillItemsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillItem")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.HasKey("BillItemsID");

                    b.ToTable("BillItems");

                    b.HasData(
                        new { BillItemsID = 1, BillItem = "Feeding" },
                        new { BillItemsID = 2, BillItem = "PTA Dues" },
                        new { BillItemsID = 3, BillItem = "Boarding fees" }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.ClassBills", b =>
                {
                    b.Property<int>("ClassBillsID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("BillItemsID");

                    b.Property<int>("ClassesID");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("DatePrepared");

                    b.Property<byte?>("TermsID");

                    b.Property<short>("YearGroup");

                    b.HasKey("ClassBillsID");

                    b.HasIndex("BillItemsID");

                    b.HasIndex("ClassesID");

                    b.HasIndex("TermsID");

                    b.ToTable("ClassBills");
                });

            modelBuilder.Entity("YouthApp.Models.Classes", b =>
                {
                    b.Property<int>("ClassesID")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("AddYear");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("IsActive");

                    b.Property<short>("ProgramsID");

                    b.HasKey("ClassesID");

                    b.HasIndex("ProgramsID");

                    b.ToTable("Classes");

                    b.HasData(
                        new { ClassesID = 1, AddYear = (short)2017, ClassName = "DM17", IsActive = true, ProgramsID = (short)1 },
                        new { ClassesID = 2, AddYear = (short)2018, ClassName = "DM18", IsActive = true, ProgramsID = (short)1 },
                        new { ClassesID = 3, AddYear = (short)2017, ClassName = "MS17", IsActive = true, ProgramsID = (short)2 },
                        new { ClassesID = 4, AddYear = (short)2018, ClassName = "MS18", IsActive = true, ProgramsID = (short)2 },
                        new { ClassesID = 5, AddYear = (short)2017, ClassName = "CJ17", IsActive = true, ProgramsID = (short)3 },
                        new { ClassesID = 6, AddYear = (short)2018, ClassName = "CJ18", IsActive = true, ProgramsID = (short)3 },
                        new { ClassesID = 7, AddYear = (short)2018, ClassName = "COOK17", IsActive = true, ProgramsID = (short)4 },
                        new { ClassesID = 8, AddYear = (short)2017, ClassName = "COOK18", IsActive = true, ProgramsID = (short)4 },
                        new { ClassesID = 9, AddYear = (short)2018, ClassName = "AG17", IsActive = true, ProgramsID = (short)5 },
                        new { ClassesID = 10, AddYear = (short)2017, ClassName = "AG18", IsActive = true, ProgramsID = (short)5 },
                        new { ClassesID = 11, AddYear = (short)2018, ClassName = "HND17", IsActive = true, ProgramsID = (short)6 },
                        new { ClassesID = 12, AddYear = (short)2017, ClassName = "HND18", IsActive = true, ProgramsID = (short)6 },
                        new { ClassesID = 13, AddYear = (short)2018, ClassName = "ELEC17", IsActive = true, ProgramsID = (short)7 },
                        new { ClassesID = 14, AddYear = (short)2017, ClassName = "ELEC18", IsActive = true, ProgramsID = (short)7 },
                        new { ClassesID = 15, AddYear = (short)2016, ClassName = "AG16", IsActive = true, ProgramsID = (short)5 }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.IndividualBills", b =>
                {
                    b.Property<long>("IndividualBillsID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("DateBilled");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("GCR")
                        .HasMaxLength(20);

                    b.Property<bool>("IsPaid");

                    b.Property<long>("StudentsID");

                    b.HasKey("IndividualBillsID");

                    b.HasIndex("StudentsID");

                    b.ToTable("IndividualBills");
                });

            modelBuilder.Entity("YouthApp.Models.Payments", b =>
                {
                    b.Property<Guid>("PaymentsID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("DatePaid");

                    b.Property<string>("GCR")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Receiver")
                        .HasMaxLength(50);

                    b.Property<long>("StudentsID");

                    b.HasKey("PaymentsID");

                    b.HasIndex("StudentsID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("YouthApp.Models.Programs", b =>
                {
                    b.Property<short>("ProgramsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProgramName");

                    b.HasKey("ProgramsID");

                    b.ToTable("Programs");

                    b.HasData(
                        new { ProgramsID = (short)1, ProgramName = "Dress Making" },
                        new { ProgramsID = (short)2, ProgramName = "Masonry" },
                        new { ProgramsID = (short)3, ProgramName = "CARPENTRY & JOINERY DEPARTMENT" },
                        new { ProgramsID = (short)4, ProgramName = "COOKERY DEPARTMENT" },
                        new { ProgramsID = (short)5, ProgramName = "AGRICULTURE DEPARTMENT" },
                        new { ProgramsID = (short)6, ProgramName = "HANDWEAVING DEPARTMENT" },
                        new { ProgramsID = (short)7, ProgramName = "ELECTRICAL DEPARTMENT" }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.Revenues", b =>
                {
                    b.Property<short>("RevenuesID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("RevenuesID");

                    b.ToTable("Revenues");

                    b.HasData(
                        new { RevenuesID = (short)1, AccountName = "NYLSTC", AccountNumber = "558964523", Bank = "Agricultural Development Bank", Source = "GOG" },
                        new { RevenuesID = (short)2, AccountName = "NYLSTC", AccountNumber = "09876547", Bank = "Tisungtaba", Source = "IGF" }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.Students", b =>
                {
                    b.Property<long>("StudentsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassesID");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateRegistered");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("OtherNames")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UniqueID")
                        .HasMaxLength(20);

                    b.HasKey("StudentsID");

                    b.HasIndex("ClassesID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("YouthApp.Models.StudentsInfo", b =>
                {
                    b.Property<long>("StudentsID");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Father")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Mother")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("StudentsID");

                    b.ToTable("StudentsInfo");
                });

            modelBuilder.Entity("YouthApp.Models.Terms", b =>
                {
                    b.Property<byte>("TermsID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<float>("Term");

                    b.HasKey("TermsID");

                    b.ToTable("Terms");

                    b.HasData(
                        new { TermsID = (byte)1, Description = "Year 1 term 1", Term = 1.1f },
                        new { TermsID = (byte)2, Description = "Year 1 term 2", Term = 1.2f },
                        new { TermsID = (byte)3, Description = "Year 1 term 3", Term = 1.3f },
                        new { TermsID = (byte)4, Description = "Year 2 term 1", Term = 2.1f },
                        new { TermsID = (byte)5, Description = "Year 2 term 2", Term = 2.2f },
                        new { TermsID = (byte)6, Description = "Year 2 term 3", Term = 2.3f },
                        new { TermsID = (byte)7, Description = "Year 3 term 1", Term = 3.1f },
                        new { TermsID = (byte)8, Description = "Year 3 term 2", Term = 3.2f },
                        new { TermsID = (byte)9, Description = "Year 3 term 3", Term = 3.3f }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.TransactionItems", b =>
                {
                    b.Property<short>("TransactionItemsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TransactionItem")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TransactionItemsID");

                    b.ToTable("TransactionItems");

                    b.HasData(
                        new { TransactionItemsID = (short)1, TransactionItem = "T&T" },
                        new { TransactionItemsID = (short)2, TransactionItem = "Fuel" },
                        new { TransactionItemsID = (short)3, TransactionItem = "Bank Charges" },
                        new { TransactionItemsID = (short)4, TransactionItem = "Maintenance" },
                        new { TransactionItemsID = (short)5, TransactionItem = "Staff Allowances" },
                        new { TransactionItemsID = (short)6, TransactionItem = "Stationery" }
                    );
                });

            modelBuilder.Entity("YouthApp.Models.Transactions", b =>
                {
                    b.Property<long>("TransactionsID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("IsStudent");

                    b.Property<short>("RevenuesID");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<short>("TransactionItemsID");

                    b.Property<short>("TransactionsTypesID");

                    b.HasKey("TransactionsID");

                    b.HasIndex("RevenuesID");

                    b.HasIndex("TransactionItemsID");

                    b.HasIndex("TransactionsTypesID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("YouthApp.Models.TransactionsTypes", b =>
                {
                    b.Property<short>("TransactionsTypesID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("TransactionsTypesID");

                    b.ToTable("TransactionsTypes");

                    b.HasData(
                        new { TransactionsTypesID = (short)1, TransactionType = "Revenue" },
                        new { TransactionsTypesID = (short)2, TransactionType = "Expenditure" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("YouthApp.Context.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YouthApp.Context.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouthApp.Context.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YouthApp.Context.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.ClassBills", b =>
                {
                    b.HasOne("YouthApp.Models.BillItems", "BillItems")
                        .WithMany("ClassBills")
                        .HasForeignKey("BillItemsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouthApp.Models.Classes", "Classes")
                        .WithMany("ClassBills")
                        .HasForeignKey("ClassesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouthApp.Models.Terms", "Terms")
                        .WithMany()
                        .HasForeignKey("TermsID");
                });

            modelBuilder.Entity("YouthApp.Models.Classes", b =>
                {
                    b.HasOne("YouthApp.Models.Programs", "Programs")
                        .WithMany("Classes")
                        .HasForeignKey("ProgramsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.IndividualBills", b =>
                {
                    b.HasOne("YouthApp.Models.Students", "Students")
                        .WithMany("IndividualBills")
                        .HasForeignKey("StudentsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.Payments", b =>
                {
                    b.HasOne("YouthApp.Models.Students", "Students")
                        .WithMany("Payments")
                        .HasForeignKey("StudentsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.Students", b =>
                {
                    b.HasOne("YouthApp.Models.Classes", "Classes")
                        .WithMany("Students")
                        .HasForeignKey("ClassesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.StudentsInfo", b =>
                {
                    b.HasOne("YouthApp.Models.Students", "Students")
                        .WithOne("StudentsInfo")
                        .HasForeignKey("YouthApp.Models.StudentsInfo", "StudentsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YouthApp.Models.Transactions", b =>
                {
                    b.HasOne("YouthApp.Models.Revenues", "Revenues")
                        .WithMany()
                        .HasForeignKey("RevenuesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouthApp.Models.TransactionItems", "TransactionItems")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionItemsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YouthApp.Models.TransactionsTypes", "TransactionsTypes")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionsTypesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

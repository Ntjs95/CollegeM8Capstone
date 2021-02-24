﻿// <auto-generated />
using System;
using CollegeM8;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollegeM8.Migrations
{
    [DbContext(typeof(CollegeM8Context))]
    partial class CollegeM8ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CollegeM8.Assignment", b =>
                {
                    b.Property<string>("AssignmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeWeight")
                        .HasColumnType("int");

                    b.Property<float>("HoursToComplete")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TermId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("CollegeM8.Class", b =>
                {
                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<string>("TermId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("ClassId");

                    b.HasIndex("TermId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CollegeM8.Exam", b =>
                {
                    b.Property<string>("ExamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TermId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamId");

                    b.HasIndex("ClassId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("CollegeM8.Login", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AccountCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordLastChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("CollegeM8.ScheduleItem", b =>
                {
                    b.Property<string>("ScheduleItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ScheduleItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("CollegeM8.Sleep", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("HoursWeekday")
                        .HasColumnType("real");

                    b.Property<float>("HoursWeekend")
                        .HasColumnType("real");

                    b.Property<DateTime>("WakeTimeWeekday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WakeTimeWeekend")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Sleep");
                });

            modelBuilder.Entity("CollegeM8.Term", b =>
                {
                    b.Property<string>("TermId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TermId");

                    b.HasIndex("UserId");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("CollegeM8.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollegeM8.Assignment", b =>
                {
                    b.HasOne("CollegeM8.Class", null)
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId");
                });

            modelBuilder.Entity("CollegeM8.Class", b =>
                {
                    b.HasOne("CollegeM8.Term", null)
                        .WithMany("Classes")
                        .HasForeignKey("TermId");
                });

            modelBuilder.Entity("CollegeM8.Exam", b =>
                {
                    b.HasOne("CollegeM8.Class", null)
                        .WithMany("Exams")
                        .HasForeignKey("ClassId");
                });

            modelBuilder.Entity("CollegeM8.Login", b =>
                {
                    b.HasOne("CollegeM8.User", null)
                        .WithOne("Login")
                        .HasForeignKey("CollegeM8.Login", "UserId");
                });

            modelBuilder.Entity("CollegeM8.ScheduleItem", b =>
                {
                    b.HasOne("CollegeM8.User", null)
                        .WithMany("ScheduleItems")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CollegeM8.Sleep", b =>
                {
                    b.HasOne("CollegeM8.User", "User")
                        .WithOne("Sleep")
                        .HasForeignKey("CollegeM8.Sleep", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollegeM8.Term", b =>
                {
                    b.HasOne("CollegeM8.User", null)
                        .WithMany("Terms")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CollegeM8.Class", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Exams");
                });

            modelBuilder.Entity("CollegeM8.Term", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("CollegeM8.User", b =>
                {
                    b.Navigation("Login");

                    b.Navigation("ScheduleItems");

                    b.Navigation("Sleep");

                    b.Navigation("Terms");
                });
#pragma warning restore 612, 618
        }
    }
}

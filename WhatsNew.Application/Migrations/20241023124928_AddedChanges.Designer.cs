﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatsNew.Application;

#nullable disable

namespace WhatsNew.Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241023124928_AddedChanges")]
    partial class AddedChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WhatsNew.Application.Models.ActionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActionTypes");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AnnouncedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AnnouncementType")
                        .HasColumnType("int");

                    b.Property<bool>("IsPopup")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsMajor")
                        .HasColumnType("bit");

                    b.Property<int>("RoleTagId")
                        .HasColumnType("int");

                    b.Property<int>("TopicTagId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("RoleTagId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.FeatureGuide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Steps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureGuides");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.FeatureSteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ComponentGroupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComponentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeatureGuideId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("TextMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FeatureSteps");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoleGroups");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.RoleTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("RoleTags");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.SubFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("SubFeatures");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.TopicGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("TopicGroup");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.TopicTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicGroupId");

                    b.ToTable("TopicTags");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArcadeAuthentication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleTagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleTagId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.Feature", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.Announcement", "Announcement")
                        .WithMany()
                        .HasForeignKey("AnnouncementId");

                    b.HasOne("WhatsNew.Application.Models.RoleTag", "RoleTag")
                        .WithMany()
                        .HasForeignKey("RoleTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");

                    b.Navigation("RoleTag");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.FeatureGuide", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.Feature", null)
                        .WithMany("FeatureGuides")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhatsNew.Application.Models.RoleTag", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.RoleGroup", "RoleGroup")
                        .WithMany()
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.SubFeature", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.Feature", "Feature")
                        .WithMany("SubFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.TopicGroup", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.RoleGroup", "RoleGroup")
                        .WithMany()
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.TopicTag", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.TopicGroup", "TopicGroup")
                        .WithMany()
                        .HasForeignKey("TopicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TopicGroup");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.User", b =>
                {
                    b.HasOne("WhatsNew.Application.Models.RoleTag", "RoleTag")
                        .WithMany()
                        .HasForeignKey("RoleTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleTag");
                });

            modelBuilder.Entity("WhatsNew.Application.Models.Feature", b =>
                {
                    b.Navigation("FeatureGuides");

                    b.Navigation("SubFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}
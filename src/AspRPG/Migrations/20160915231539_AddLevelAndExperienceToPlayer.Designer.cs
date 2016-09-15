using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspRPG.Data;

namespace AspRPG.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160915231539_AddLevelAndExperienceToPlayer")]
    partial class AddLevelAndExperienceToPlayer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspRPG.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AspRPG.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EastDoor");

                    b.Property<bool>("HasRoom");

                    b.Property<bool>("IsOccupied");

                    b.Property<int>("MapId");

                    b.Property<bool>("NorthDoor");

                    b.Property<bool>("SouthDoor");

                    b.Property<bool>("Visited");

                    b.Property<bool>("WestDoor");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AspRPG.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("AspRPG.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DmgMod");

                    b.Property<int>("Exp");

                    b.Property<int>("Hp");

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("AspRPG.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CurrentRoomId");

                    b.Property<int>("DmgMod");

                    b.Property<int>("Exp");

                    b.Property<int>("Hp");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("AspRPG.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DmgMod");

                    b.Property<int?>("MonsterId");

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AspRPG.Models.Location", b =>
                {
                    b.HasOne("AspRPG.Models.Map", "Map")
                        .WithMany("Locations")
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("AspRPG.Models.Monster", b =>
                {
                    b.HasOne("AspRPG.Models.Location", "Location")
                        .WithMany("Monsters")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("AspRPG.Models.Player", b =>
                {
                    b.HasOne("AspRPG.Models.Location", "CurrentRoom")
                        .WithMany()
                        .HasForeignKey("CurrentRoomId");

                    b.HasOne("AspRPG.Models.ApplicationUser", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AspRPG.Models.Weapon", b =>
                {
                    b.HasOne("AspRPG.Models.Monster", "Monster")
                        .WithOne("Weapon")
                        .HasForeignKey("AspRPG.Models.Weapon", "MonsterId");

                    b.HasOne("AspRPG.Models.Player", "Player")
                        .WithOne("Weapon")
                        .HasForeignKey("AspRPG.Models.Weapon", "PlayerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AspRPG.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AspRPG.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("AspRPG.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProfessionalNetwork.Models;

namespace ProfessionalNetwork.Migrations
{
    [DbContext(typeof(ProfessionalPlannerContext))]
    [Migration("20170421174529_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("ProfessionalNetwork.Models.Network", b =>
                {
                    b.Property<int>("NetworkId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Status");

                    b.Property<int>("UserConnectedId");

                    b.Property<int>("UserId");

                    b.HasKey("NetworkId");

                    b.HasIndex("UserConnectedId");

                    b.HasIndex("UserId");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("ProfessionalNetwork.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_At");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProfessionalNetwork.Models.Network", b =>
                {
                    b.HasOne("ProfessionalNetwork.Models.User", "UserConnected")
                        .WithMany("UsersConnectedToList")
                        .HasForeignKey("UserConnectedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProfessionalNetwork.Models.User", "User")
                        .WithMany("Networks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

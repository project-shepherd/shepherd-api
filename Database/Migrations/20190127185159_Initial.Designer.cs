﻿// <auto-generated />
using System;
using Database.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(ShepherdContext))]
    [Migration("20190127185159_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FunctionApp.Persistence.Models.Commitment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("TopicId");

                    b.Property<Guid>("TypeId");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Commitments");
                });

            modelBuilder.Entity("FunctionApp.Persistence.Models.CommitmentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.ToTable("CommitmentTypes");

                    b.HasData(
                        new { Id = new Guid("e130479b-8009-4941-a3ee-f0292bbcfe23"), CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "BFF", UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = new Guid("0a196ec9-4d23-4a32-84ff-dbf0852a898e"), CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Blog post", UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = new Guid("606c603f-3997-4f5f-b115-b7629075428a"), CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Lightning talk", UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("FunctionApp.Persistence.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("AcceptanceCriteria")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("RequestorId");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.HasIndex("RequestorId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("FunctionApp.Persistence.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("1d982bf6-a353-4741-867c-ed2c46090984"), CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Brandon Barnett", TenantId = "Test", UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("FunctionApp.Persistence.Models.Commitment", b =>
                {
                    b.HasOne("FunctionApp.Persistence.Models.Topic", "Topic")
                        .WithMany("Commitments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FunctionApp.Persistence.Models.CommitmentType", "Type")
                        .WithMany("Commitments")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FunctionApp.Persistence.Models.User", "User")
                        .WithMany("Commitments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FunctionApp.Persistence.Models.Topic", b =>
                {
                    b.HasOne("FunctionApp.Persistence.Models.User", "Requestor")
                        .WithMany("Topics")
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

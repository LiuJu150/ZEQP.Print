﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZEQP.Print.Entities;

namespace ZEQP.Print.Entities.Migrations
{
    [DbContext(typeof(PrintContext))]
    [Migration("20200115012356_AddTemplateFields")]
    partial class AddTemplateFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("ZEQP.Print.Entities.PrintTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<int>("Copies")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWait")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifyTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT");

                    b.Property<int>("PrintCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrintName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Query")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TemplateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("PrintTasks");
                });

            modelBuilder.Entity("ZEQP.Print.Entities.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifyTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Path")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<int>("PrintCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SaveToFile")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("ZEQP.Print.Entities.TemplateField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<int>("FieldType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImgHeight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImgWidth")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifyTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("TableName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("TemplateId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("imgType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateFields");
                });

            modelBuilder.Entity("ZEQP.Print.Entities.PrintTask", b =>
                {
                    b.HasOne("ZEQP.Print.Entities.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZEQP.Print.Entities.TemplateField", b =>
                {
                    b.HasOne("ZEQP.Print.Entities.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

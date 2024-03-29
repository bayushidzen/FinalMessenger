﻿// <auto-generated />
using System;
using MessageDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MessageDataBase.Migrations
{
    [DbContext(typeof(MessagesContext))]
    [Migration("20240130091957_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MessageDataBase.BD.Message", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property<bool>("IsReceived")
                    .HasColumnType("boolean");

                b.Property<int>("ReceiverId")
                    .HasColumnType("integer");

                b.Property<int>("SenderId")
                    .HasColumnType("integer");

                b.Property<string>("Text")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)");

                b.HasKey("Id")
                    .HasName("message_pkey");

                b.HasIndex("ReceiverId");

                b.HasIndex("SenderId");

                b.ToTable("messages", (string)null);
            });

            modelBuilder.Entity("MessageDataBase.BD.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey("Id");

                b.ToTable("User");
            });

            modelBuilder.Entity("MessageDataBase.BD.Message", b =>
            {
                b.HasOne("MessageDataBase.BD.User", "Receiver")
                    .WithMany()
                    .HasForeignKey("ReceiverId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("MessageDataBase.BD.User", "Sender")
                    .WithMany()
                    .HasForeignKey("SenderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Receiver");

                b.Navigation("Sender");
            });
#pragma warning restore 612, 618
        }
    }
}
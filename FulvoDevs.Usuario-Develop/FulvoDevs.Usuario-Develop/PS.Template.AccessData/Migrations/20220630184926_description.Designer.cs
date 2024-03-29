﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Template.AccessData.DBContext;

#nullable disable

namespace PS.Template.AccessData.Migrations
{
    [DbContext(typeof(ProyectoSoftwareContext))]
    [Migration("20220630184926_description")]
    partial class description
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PS.Template.Domain.Models.Features", b =>
                {
                    b.Property<int>("Caracteristica_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Caracteristica_Id"), 1L, 1);

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<bool>("softDelete")
                        .HasColumnType("bit");

                    b.HasKey("Caracteristica_Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("features");
                });

            modelBuilder.Entity("PS.Template.Domain.Models.Follow", b =>
                {
                    b.Property<int>("FollowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FollowKey"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("seguido_Fk")
                        .HasColumnType("int");

                    b.Property<bool>("softDelete")
                        .HasColumnType("bit");

                    b.Property<int>("usuario_Fk")
                        .HasColumnType("int");

                    b.HasKey("FollowKey");

                    b.HasIndex("seguido_Fk");

                    b.HasIndex("usuario_Fk");

                    b.ToTable("follows");
                });

            modelBuilder.Entity("PS.Template.Domain.Models.User", b =>
                {
                    b.Property<int>("Usuario_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Usuario_Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IsCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.Property<string>("profilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("softDelete")
                        .HasColumnType("bit");

                    b.HasKey("Usuario_Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PS.Template.Domain.Models.Features", b =>
                {
                    b.HasOne("PS.Template.Domain.Models.User", "Usuario")
                        .WithMany("features")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PS.Template.Domain.Models.Follow", b =>
                {
                    b.HasOne("PS.Template.Domain.Models.User", "Seguido")
                        .WithMany("followers")
                        .HasForeignKey("seguido_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PS.Template.Domain.Models.User", "Usuario_Id")
                        .WithMany("follows")
                        .HasForeignKey("usuario_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seguido");

                    b.Navigation("Usuario_Id");
                });

            modelBuilder.Entity("PS.Template.Domain.Models.User", b =>
                {
                    b.Navigation("features");

                    b.Navigation("followers");

                    b.Navigation("follows");
                });
#pragma warning restore 612, 618
        }
    }
}

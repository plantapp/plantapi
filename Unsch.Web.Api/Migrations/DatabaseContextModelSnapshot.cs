﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Unsch.Web.Api.Repository;

namespace Unsch.Web.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Unsch.Web.Api.Model.PlantaEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Clase")
                        .HasColumnName("CLASE")
                        .HasMaxLength(200);

                    b.Property<string>("Descripcion")
                        .HasColumnName("DESCRIPCION")
                        .HasMaxLength(800);

                    b.Property<string>("Division")
                        .HasColumnName("DIVISION")
                        .HasMaxLength(200);

                    b.Property<string>("Especie")
                        .HasColumnName("ESPECIE")
                        .HasMaxLength(200);

                    b.Property<string>("Familia")
                        .HasColumnName("FAMILIA")
                        .HasMaxLength(200);

                    b.Property<string>("Fecha")
                        .HasColumnName("FECHA")
                        .HasMaxLength(100);

                    b.Property<string>("Genero")
                        .HasColumnName("GENERO")
                        .HasMaxLength(200);

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnName("IMAGEN_BASE64");

                    b.Property<string>("ImagenName")
                        .IsRequired()
                        .HasColumnName("NOMBRE_ARCHIVO")
                        .HasMaxLength(100);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("NOMBRE_PLANTA")
                        .HasMaxLength(200);

                    b.Property<string>("Orden")
                        .HasColumnName("ORDEN")
                        .HasMaxLength(200);

                    b.Property<string>("Reino")
                        .HasColumnName("REINO")
                        .HasMaxLength(200);

                    b.Property<string>("SubClase")
                        .HasColumnName("SUB_CLASE")
                        .HasMaxLength(200);

                    b.Property<string>("SubFamilia")
                        .HasColumnName("SUB_FAMILIA")
                        .HasMaxLength(200);

                    b.Property<string>("Tribu")
                        .HasColumnName("TRIBU")
                        .HasMaxLength(200);

                    b.Property<string>("Ubicacion")
                        .HasColumnName("UBICACION")
                        .HasMaxLength(200);

                    b.Property<string>("UsuarioId")
                        .HasColumnName("USURARIO_ID")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("T_PLANTA");
                });

            modelBuilder.Entity("Unsch.Web.Api.Model.UsuarioEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnName("IMAGE");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnName("NOMBRES")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("T_USUARIO");
                });
#pragma warning restore 612, 618
        }
    }
}

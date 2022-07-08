﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaEscolar.Data;

namespace sistemaEscolar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlunoModelProfessorModel", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("AlunoModelProfessorModel");
                });

            modelBuilder.Entity("ProfessorModelSalaModel", b =>
                {
                    b.Property<int>("ProfessoresId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessoresId", "SalaId");

                    b.HasIndex("SalaId");

                    b.ToTable("ProfessorModelSalaModel");
                });

            modelBuilder.Entity("sistemaEscolar.Model.AlunoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprovado")
                        .HasColumnType("bit");

                    b.Property<float>("Media")
                        .HasColumnType("real");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Nota1")
                        .HasColumnType("real");

                    b.Property<float>("Nota2")
                        .HasColumnType("real");

                    b.Property<float>("Nota3")
                        .HasColumnType("real");

                    b.Property<float>("NotaFinal")
                        .HasColumnType("real");

                    b.Property<float>("NotaRecuperacao")
                        .HasColumnType("real");

                    b.Property<bool>("Recuperacao")
                        .HasColumnType("bit");

                    b.Property<bool>("Reprovado")
                        .HasColumnType("bit");

                    b.Property<int?>("SalaModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaModelId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("sistemaEscolar.Model.ProfessorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("sistemaEscolar.Model.SalaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Identificador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("AlunoModelProfessorModel", b =>
                {
                    b.HasOne("sistemaEscolar.Model.AlunoModel", null)
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaEscolar.Model.ProfessorModel", null)
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorModelSalaModel", b =>
                {
                    b.HasOne("sistemaEscolar.Model.ProfessorModel", null)
                        .WithMany()
                        .HasForeignKey("ProfessoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaEscolar.Model.SalaModel", null)
                        .WithMany()
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sistemaEscolar.Model.AlunoModel", b =>
                {
                    b.HasOne("sistemaEscolar.Model.SalaModel", null)
                        .WithMany("Alunos")
                        .HasForeignKey("SalaModelId");
                });

            modelBuilder.Entity("sistemaEscolar.Model.SalaModel", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}

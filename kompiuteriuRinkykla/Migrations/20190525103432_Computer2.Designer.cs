﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kompiuteriuRinkykla.Models;

namespace kompiuteriuRinkykla.Migrations
{
    [DbContext(typeof(computerAssemblyContext))]
    [Migration("20190525103432_Computer2")]
    partial class Computer2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kompiuteriuRinkykla.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.Property<string>("Purpose");

                    b.HasKey("Id");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("kompiuteriuRinkykla.Models.ComputerPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("PartId");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("PartId");

                    b.ToTable("ComputerPart");
                });

            modelBuilder.Entity("kompiuteriuRinkykla.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Color");

                    b.Property<string>("ConnectionType");

                    b.Property<int>("CoreCount");

                    b.Property<string>("CpuConnType");

                    b.Property<string>("DataStorageInterface");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("EfficiencyRating");

                    b.Property<double>("Height");

                    b.Property<double>("Length");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<double>("MaxDataStorageLength");

                    b.Property<double>("MaxGpuLength");

                    b.Property<double>("MaxMotherboardLength");

                    b.Property<double>("MaxPsuLength");

                    b.Property<int>("MaxRam");

                    b.Property<int>("MemoryGb");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("MonitorSocketCount");

                    b.Property<int>("PartTypeId");

                    b.Property<int>("PciSocketCount");

                    b.Property<int>("Power");

                    b.Property<double>("Price");

                    b.Property<double>("ProcessorFrequency");

                    b.Property<int>("Qty")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("RamConnType");

                    b.Property<int>("RamSocketCount");

                    b.Property<string>("Type");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.HasIndex("PartTypeId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("kompiuteriuRinkykla.Models.PartType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PartType");
                });

            modelBuilder.Entity("kompiuteriuRinkykla.Models.ComputerPart", b =>
                {
                    b.HasOne("kompiuteriuRinkykla.Models.Computer", "Computer")
                        .WithMany("ComputerParts")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kompiuteriuRinkykla.Models.Part", "Part")
                        .WithMany("ComputerParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kompiuteriuRinkykla.Models.Part", b =>
                {
                    b.HasOne("kompiuteriuRinkykla.Models.PartType", "PartType")
                        .WithMany("Parts")
                        .HasForeignKey("PartTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

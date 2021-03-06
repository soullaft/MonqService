// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonqService.Data;

namespace MonqService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("MonqService.Models.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FailedMessage")
                        .HasColumnType("TEXT");

                    b.Property<int>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("MonqService.Models.Recicpients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MailId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MailId");

                    b.ToTable("Recicpients");
                });

            modelBuilder.Entity("MonqService.Models.Recicpients", b =>
                {
                    b.HasOne("MonqService.Models.Mail", null)
                        .WithMany("Recicpients")
                        .HasForeignKey("MailId");
                });

            modelBuilder.Entity("MonqService.Models.Mail", b =>
                {
                    b.Navigation("Recicpients");
                });
#pragma warning restore 612, 618
        }
    }
}

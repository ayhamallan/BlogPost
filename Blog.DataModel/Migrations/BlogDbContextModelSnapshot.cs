﻿// <auto-generated />
using System;
using Blog.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.DataModel.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.DataModel.DataModels.BlogPost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auther");

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Subtitle");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Auther = "Auther1",
                            Body = "Post Body1",
                            CreationDate = new DateTime(2019, 10, 25, 17, 11, 58, 521, DateTimeKind.Local).AddTicks(3681),
                            ImageUrl = "Image1",
                            Subtitle = "Subtitle1",
                            Title = "Title1"
                        },
                        new
                        {
                            ID = 2,
                            Auther = "Auther2",
                            Body = "Post Body2",
                            CreationDate = new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(273),
                            ImageUrl = "Image2",
                            Subtitle = "Subtitle2",
                            Title = "Title2"
                        },
                        new
                        {
                            ID = 3,
                            Auther = "Auther3",
                            Body = "Post Body3",
                            CreationDate = new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(290),
                            ImageUrl = "Image3",
                            Subtitle = "Subtitle3",
                            Title = "Title3"
                        },
                        new
                        {
                            ID = 4,
                            Auther = "Auther4",
                            Body = "Post Body4",
                            CreationDate = new DateTime(2019, 10, 25, 17, 11, 58, 524, DateTimeKind.Local).AddTicks(294),
                            ImageUrl = "Image4",
                            Subtitle = "Subtitle4",
                            Title = "Title4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

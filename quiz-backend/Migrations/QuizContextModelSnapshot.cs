﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using quiz_backend;
using System;

namespace quiz_backend.Migrations
{
    [DbContext(typeof(QuizContext))]
    partial class QuizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("quiz_backend.Models.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<bool>("isSubscribed");

                    b.Property<string>("url");

                    b.HasKey("Id");

                    b.ToTable("Feed");
                });

            modelBuilder.Entity("quiz_backend.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer1");

                    b.Property<string>("Answer2");

                    b.Property<string>("Answer3");

                    b.Property<string>("Answer4");

                    b.Property<string>("CorrectAnswer");

                    b.Property<int>("QuizId");

                    b.Property<string>("Text");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("quiz_backend.Models.Quiz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OwnerId");

                    b.Property<string>("TestFieldXXXXXX");

                    b.Property<string>("Title");

                    b.Property<string>("okTestColumn");

                    b.HasKey("ID");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("quiz_backend.Models.UserFeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FeedId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserFeed");
                });
#pragma warning restore 612, 618
        }
    }
}

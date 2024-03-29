﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XtxDocumentation.DocApi.Data;

namespace XtxDocumentation.DocApi.Migrations
{
    [DbContext(typeof(DocuDbContext))]
    partial class DocuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.DocumentModel", b =>
                {
                    b.Property<long>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocContent")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("DocTitle")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DocVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectModelId")
                        .HasColumnType("int");

                    b.Property<int>("StateModelId")
                        .HasColumnType("int");

                    b.Property<int>("TypeModelId")
                        .HasColumnType("int");

                    b.Property<int>("UserModelId")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.HasIndex("ProjectModelId");

                    b.HasIndex("StateModelId");

                    b.HasIndex("TypeModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("DocumentModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.FigureModel", b =>
                {
                    b.Property<int>("FigureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FigureTitle")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullPath")
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("FigureId");

                    b.ToTable("FigureModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.ProjectModel", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectLeader")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.RemarkModel", b =>
                {
                    b.Property<int>("RemarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DocumentModelDocumentId")
                        .HasColumnType("bigint");

                    b.Property<int>("DocumentModelId")
                        .HasColumnType("int");

                    b.Property<string>("RemarkText")
                        .HasColumnType("nvarchar(Max)");

                    b.HasKey("RemarkId");

                    b.HasIndex("DocumentModelDocumentId");

                    b.ToTable("RemarkModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.StateModel", b =>
                {
                    b.Property<int>("DocEditStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EditState")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocEditStateId");

                    b.ToTable("StateModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.TypeModel", b =>
                {
                    b.Property<int>("TypeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModelType")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TypeModelId");

                    b.ToTable("TypeModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.DocumentModel", b =>
                {
                    b.HasOne("XtxDocumentation.DocApi.Data.ProjectModel", "ProjectModel")
                        .WithMany()
                        .HasForeignKey("ProjectModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XtxDocumentation.DocApi.Data.StateModel", "StateModel")
                        .WithMany()
                        .HasForeignKey("StateModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XtxDocumentation.DocApi.Data.TypeModel", "TypeModel")
                        .WithMany()
                        .HasForeignKey("TypeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XtxDocumentation.DocApi.Data.UserModel", "UserModel")
                        .WithMany()
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectModel");

                    b.Navigation("StateModel");

                    b.Navigation("TypeModel");

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("XtxDocumentation.DocApi.Data.RemarkModel", b =>
                {
                    b.HasOne("XtxDocumentation.DocApi.Data.DocumentModel", "DocumentModel")
                        .WithMany()
                        .HasForeignKey("DocumentModelDocumentId");

                    b.Navigation("DocumentModel");
                });
#pragma warning restore 612, 618
        }
    }
}

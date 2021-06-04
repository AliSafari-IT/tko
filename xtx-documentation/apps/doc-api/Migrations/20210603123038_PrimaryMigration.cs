using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XtxDocumentation.DocApi.Migrations
{
    public partial class PrimaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FigureModels",
                columns: table => new
                {
                    FigureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FigureTitle = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FigureModels", x => x.FigureId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModels",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectLeader = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModels", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "StateModels",
                columns: table => new
                {
                    DocEditStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditState = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateModels", x => x.DocEditStateId);
                });

            migrationBuilder.CreateTable(
                name: "TypeModels",
                columns: table => new
                {
                    TypeModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelType = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeModels", x => x.TypeModelId);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentModels",
                columns: table => new
                {
                    DocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocTitle = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DocContent = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StateModelId = table.Column<int>(type: "int", nullable: false),
                    TypeModelId = table.Column<int>(type: "int", nullable: false),
                    ProjectModelId = table.Column<int>(type: "int", nullable: false),
                    UserModelId = table.Column<int>(type: "int", nullable: false),
                    DocVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentModels", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_DocumentModels_ProjectModels_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModels",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentModels_StateModels_StateModelId",
                        column: x => x.StateModelId,
                        principalTable: "StateModels",
                        principalColumn: "DocEditStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentModels_TypeModels_TypeModelId",
                        column: x => x.TypeModelId,
                        principalTable: "TypeModels",
                        principalColumn: "TypeModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentModels_UserModels_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemarkModels",
                columns: table => new
                {
                    RemarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemarkText = table.Column<string>(type: "nvarchar(Max)", nullable: true),
                    DocumentModelId = table.Column<int>(type: "int", nullable: false),
                    DocumentModelDocumentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemarkModels", x => x.RemarkId);
                    table.ForeignKey(
                        name: "FK_RemarkModels_DocumentModels_DocumentModelDocumentId",
                        column: x => x.DocumentModelDocumentId,
                        principalTable: "DocumentModels",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_ProjectModelId",
                table: "DocumentModels",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_StateModelId",
                table: "DocumentModels",
                column: "StateModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_TypeModelId",
                table: "DocumentModels",
                column: "TypeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_UserModelId",
                table: "DocumentModels",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RemarkModels_DocumentModelDocumentId",
                table: "RemarkModels",
                column: "DocumentModelDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FigureModels");

            migrationBuilder.DropTable(
                name: "RemarkModels");

            migrationBuilder.DropTable(
                name: "DocumentModels");

            migrationBuilder.DropTable(
                name: "ProjectModels");

            migrationBuilder.DropTable(
                name: "StateModels");

            migrationBuilder.DropTable(
                name: "TypeModels");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}

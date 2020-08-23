using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesTracker.API.Data.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    ParentCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsPublic = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Concepts",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_UserCategories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    InstitutionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_InstitutionBranches",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstitutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false),
                    InstitutionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_UserInstitutions",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConcepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false),
                    ConceptId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConcepts_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false),
                    InstitutionBranchId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_Operations",
                        column: x => x.InstitutionBranchId,
                        principalTable: "InstitutionBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstitutionBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false),
                    InstitutionBranchId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitutionBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionBranch_UserInstitutionBranches",
                        column: x => x.InstitutionBranchId,
                        principalTable: "InstitutionBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    ConceptId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_OperationDetails",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Currency_OperationDetails",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_OperationDetails",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_OperationMovements",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Currency_OperationMovements",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_OperationMovements",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdentityId",
                table: "Accounts",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_CategoryId",
                table: "Concepts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionBranches_InstitutionId",
                table: "InstitutionBranches",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_ConceptId",
                table: "OperationDetails",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_CurrencyId",
                table: "OperationDetails",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_OperationId",
                table: "OperationDetails",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationMovements_AccountId",
                table: "OperationMovements",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationMovements_CurrencyId",
                table: "OperationMovements",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationMovements_OperationId",
                table: "OperationMovements",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_IdentityId",
                table: "Operations",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_InstitutionBranchId",
                table: "Operations",
                column: "InstitutionBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_CategoryId",
                table: "UserCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConcepts_ConceptId",
                table: "UserConcepts",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutionBranches_InstitutionBranchId",
                table: "UserInstitutionBranches",
                column: "InstitutionBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutions_InstitutionId",
                table: "UserInstitutions",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationDetails");

            migrationBuilder.DropTable(
                name: "OperationMovements");

            migrationBuilder.DropTable(
                name: "UserCategories");

            migrationBuilder.DropTable(
                name: "UserConcepts");

            migrationBuilder.DropTable(
                name: "UserInstitutionBranches");

            migrationBuilder.DropTable(
                name: "UserInstitutions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Concepts");

            migrationBuilder.DropTable(
                name: "InstitutionBranches");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}

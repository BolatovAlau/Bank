using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.BusinessLogic.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TotalAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalAmounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Branch = table.Column<string>(nullable: true),
                    PhaseOfContract = table.Column<string>(nullable: true),
                    ContractStatus = table.Column<string>(nullable: true),
                    TypeOfContract = table.Column<string>(nullable: true),
                    ContractSubtype = table.Column<string>(nullable: true),
                    OwnershipType = table.Column<string>(nullable: true),
                    PurposeOfFinancing = table.Column<string>(nullable: true),
                    CurrencyOfContract = table.Column<string>(nullable: true),
                    TotalAmountId = table.Column<int>(nullable: true),
                    NextPaymentDate = table.Column<string>(nullable: true),
                    TotalMonthlyPaymentId = table.Column<int>(nullable: true),
                    PaymentPeriodicity = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    RestructuringDate = table.Column<string>(nullable: true),
                    ExpectedEndDate = table.Column<string>(nullable: true),
                    RealEndDate = table.Column<string>(nullable: true),
                    NegativeStatusOfContract = table.Column<string>(nullable: true),
                    ProlongationAmountId = table.Column<int>(nullable: true),
                    ProlongationDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDatas_TotalAmounts_ProlongationAmountId",
                        column: x => x.ProlongationAmountId,
                        principalTable: "TotalAmounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractDatas_TotalAmounts_TotalAmountId",
                        column: x => x.TotalAmountId,
                        principalTable: "TotalAmounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractDatas_TotalAmounts_TotalMonthlyPaymentId",
                        column: x => x.TotalMonthlyPaymentId,
                        principalTable: "TotalAmounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractCode = table.Column<string>(nullable: true),
                    ContractDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractDatas_ContractDataId",
                        column: x => x.ContractDataId,
                        principalTable: "ContractDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurentId = table.Column<int>(nullable: false),
                    BatchIdentifier = table.Column<string>(nullable: true),
                    ContractId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerCode = table.Column<string>(nullable: true),
                    RoleOfCustomer = table.Column<string>(nullable: true),
                    RealEndDate = table.Column<string>(nullable: true),
                    GuarantorRelationship = table.Column<string>(nullable: true),
                    ContractId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectRoles_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ContractId",
                table: "Batches",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDatas_ProlongationAmountId",
                table: "ContractDatas",
                column: "ProlongationAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDatas_TotalAmountId",
                table: "ContractDatas",
                column: "TotalAmountId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDatas_TotalMonthlyPaymentId",
                table: "ContractDatas",
                column: "TotalMonthlyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractDataId",
                table: "Contracts",
                column: "ContractDataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRoles_ContractId",
                table: "SubjectRoles",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "SubjectRoles");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractDatas");

            migrationBuilder.DropTable(
                name: "TotalAmounts");
        }
    }
}

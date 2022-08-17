using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceDB.Migrations
{
    public partial class InitiateCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GueasLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOutDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CleaningFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GuestEMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdultsAmount = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CleaningFeeTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Taxs",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    FeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestOrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TaxOrderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxs", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Taxs_Guests_GuestOrderId",
                        column: x => x.GuestOrderId,
                        principalTable: "Guests",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_Taxs_Taxs_TaxOrderId",
                        column: x => x.TaxOrderId,
                        principalTable: "Taxs",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "GuestOrder",
                columns: table => new
                {
                    GuestsOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdersOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestOrder", x => new { x.GuestsOrderId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_GuestOrder_Guests_GuestsOrderId",
                        column: x => x.GuestsOrderId,
                        principalTable: "Guests",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTax",
                columns: table => new
                {
                    OrdersOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxsOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTax", x => new { x.OrdersOrderId, x.TaxsOrderId });
                    table.ForeignKey(
                        name: "FK_OrderTax_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTax_Taxs_TaxsOrderId",
                        column: x => x.TaxsOrderId,
                        principalTable: "Taxs",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestOrder_OrdersOrderId",
                table: "GuestOrder",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTax_TaxsOrderId",
                table: "OrderTax",
                column: "TaxsOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxs_GuestOrderId",
                table: "Taxs",
                column: "GuestOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxs_TaxOrderId",
                table: "Taxs",
                column: "TaxOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestOrder");

            migrationBuilder.DropTable(
                name: "OrderTax");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Taxs");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}

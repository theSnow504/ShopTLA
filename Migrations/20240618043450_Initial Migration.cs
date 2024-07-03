using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTLA.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CatDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CatLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__6A1C8AFA1C46400F", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NatLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nations__668041083B4A3E5A", x => x.NatId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    TypeUser = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserType__E1F318E8051A5C84", x => x.TypeUser);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<int>(type: "int", nullable: true),
                    ProName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProPrice = table.Column<double>(type: "float", nullable: true),
                    ProDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NatId = table.Column<int>(type: "int", nullable: true),
                    ProLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__6202959091DE12B0", x => x.ProId);
                    table.ForeignKey(
                        name: "FK__Products__CatId__38996AB5",
                        column: x => x.CatId,
                        principalTable: "Categories",
                        principalColumn: "CatId");
                    table.ForeignKey(
                        name: "FK__Products__NatId__398D8EEE",
                        column: x => x.NatId,
                        principalTable: "Nations",
                        principalColumn: "NatId");
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TypeUser = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAcco__3214EC07D547027E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserAccou__TypeU__267ABA7A",
                        column: x => x.TypeUser,
                        principalTable: "UserTypes",
                        principalColumn: "TypeUser");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusId = table.Column<int>(type: "int", nullable: false),
                    CusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CusDateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    CusAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CusPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CusEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CusLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__2F187110E88EB5DF", x => x.CusId);
                    table.ForeignKey(
                        name: "FK__Customers__CusId__2B3F6F97",
                        column: x => x.CusId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpDateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    EmpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmpPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmpEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmpSalary = table.Column<double>(type: "float", nullable: true),
                    EmpLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__AF2DBB992BF77CF3", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK__Employees__EmpId__2F10007B",
                        column: x => x.EmpId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusId = table.Column<int>(type: "int", nullable: true),
                    OrdDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    OrdStatus = table.Column<int>(type: "int", nullable: true),
                    OrdTotal = table.Column<double>(type: "float", nullable: true),
                    OrdLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__67A28336A51F5815", x => x.OrdId);
                    table.ForeignKey(
                        name: "FK__Orders__CusId__3D5E1FD2",
                        column: x => x.CusId,
                        principalTable: "Customers",
                        principalColumn: "CusId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdId = table.Column<int>(type: "int", nullable: true),
                    ProId = table.Column<int>(type: "int", nullable: true),
                    DetQuantity = table.Column<int>(type: "int", nullable: true),
                    DetPrice = table.Column<double>(type: "float", nullable: true),
                    DetLastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D8957ADCAEF05231", x => x.DetId);
                    table.ForeignKey(
                        name: "FK__OrderDeta__OrdId__4222D4EF",
                        column: x => x.OrdId,
                        principalTable: "Orders",
                        principalColumn: "OrdId");
                    table.ForeignKey(
                        name: "FK__OrderDeta__ProId__4316F928",
                        column: x => x.ProId,
                        principalTable: "Products",
                        principalColumn: "ProId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrdId",
                table: "OrderDetails",
                column: "OrdId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProId",
                table: "OrderDetails",
                column: "ProId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CusId",
                table: "Orders",
                column: "CusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatId",
                table: "Products",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NatId",
                table: "Products",
                column: "NatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_TypeUser",
                table: "UserAccounts",
                column: "TypeUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}

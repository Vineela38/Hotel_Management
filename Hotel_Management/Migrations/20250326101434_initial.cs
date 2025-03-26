using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ForgotPassword_11",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPassword1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPassword_11", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookingtbl45",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HotelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfAdults = table.Column<int>(type: "int", nullable: false),
                    NoOfchild = table.Column<int>(type: "int", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookingtbl45", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Hotelstbl45",
                columns: table => new
                {
                    HotelId = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfACRooms = table.Column<int>(type: "int", nullable: false),
                    CostPerDay = table.Column<double>(type: "float", nullable: false),
                    NoOfNonACRooms = table.Column<int>(type: "int", nullable: false),
                    CostPerDayNonAc = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotelstbl45", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Login_15",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_15", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetailstbl45",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creditcardnumber = table.Column<long>(type: "bigint", nullable: false),
                    Bankname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cardtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameoncard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expirydate = table.Column<DateOnly>(type: "date", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    Pin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetailstbl45", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "SignUp_15",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUp_15", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgotPassword_11");

            migrationBuilder.DropTable(
                name: "HotelBookingtbl45");

            migrationBuilder.DropTable(
                name: "Hotelstbl45");

            migrationBuilder.DropTable(
                name: "Login_15");

            migrationBuilder.DropTable(
                name: "PaymentDetailstbl45");

            migrationBuilder.DropTable(
                name: "SignUp_15");
        }
    }
}

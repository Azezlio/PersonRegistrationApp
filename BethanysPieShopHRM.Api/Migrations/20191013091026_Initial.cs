using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonRegistrationApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    
                    PersonId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                   
                });

          

            //migrationBuilder.InsertData(
            //    table: "People",
            //    columns: new[] { "PersonId", "BirthDate", "City",  "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
            //    values: new object[] { 1, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "rock@bethanyspieshop.com", null, "Bethany", 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 1, "324777888773", false, "Grote Markt 1", "1000" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_People_CountryId",
            //    table: "People",
            //    column: "CountryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_People_JobCategoryId",
            //    table: "People",
            //    column: "JobCategoryId");            //migrationBuilder.InsertData(
            //    table: "People",
            //    columns: new[] { "PersonId", "BirthDate", "City",  "Email", "ExitDate", "FirstName", "Gender", "JobCategoryId", "JoinedDate", "LastName", "MaritalStatus", "PhoneNumber", "Smoker", "Street", "Zip" },
            //    values: new object[] { 1, new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "rock@bethanyspieshop.com", null, "Bethany", 1, 1, new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 1, "324777888773", false, "Grote Markt 1", "1000" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_People_CountryId",
            //    table: "People",
            //    column: "CountryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_People_JobCategoryId",
            //    table: "People",
            //    column: "JobCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

        }
    }
}

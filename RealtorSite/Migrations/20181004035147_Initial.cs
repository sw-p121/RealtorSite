using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealtorSite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bathrooms = table.Column<int>(nullable: false),
                    Bedrooms = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    DateListed = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GarageSize = table.Column<int>(nullable: false),
                    LotSize = table.Column<int>(nullable: false),
                    Mls = table.Column<int>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    Photos = table.Column<string>(nullable: true),
                    SalesPrice = table.Column<double>(nullable: false),
                    SquareFeet = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}

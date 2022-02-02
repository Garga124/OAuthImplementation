using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddCoffeeShops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('PJ''s coffee of new test','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop2','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop3','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop4','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop5','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop6','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop7','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop8','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
            migrationBuilder.Sql($"INSERT INTO CoffeeShops (Name, OpeningHours, Address) VALUES ('CoffeeShop9','9-5 Mon to Sat','NE21NY 30, Amble Grove' )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

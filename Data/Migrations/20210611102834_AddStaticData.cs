using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentalApp.Data.Migrations
{
    public partial class AddStaticData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.MembershipTypes(Name, DurationInMonths, Price,DiscountRate) VALUES( 'PayAsYouGo', 0 , 0 , 0)");
            migrationBuilder.Sql("INSERT INTO dbo.MembershipTypes(Name, DurationInMonths, Price,DiscountRate) VALUES( 'Monthly', 1 , 30 , 10)");
            migrationBuilder.Sql("INSERT INTO dbo.MembershipTypes(Name, DurationInMonths, Price,DiscountRate) VALUES( 'Quarterly', 3  , 90 , 15)");
            migrationBuilder.Sql("INSERT INTO dbo.MembershipTypes(Name, DurationInMonths, Price,DiscountRate) VALUES( 'Yearly', 12 , 300 , 20)");

            migrationBuilder.Sql("INSERT INTO dbo.Genres(Name) VALUES( 'Fiction')");
            migrationBuilder.Sql("INSERT INTO dbo.Genres(Name) VALUES( 'Comedy')");
            migrationBuilder.Sql("INSERT INTO dbo.Genres(Name) VALUES('Thriller')");
            migrationBuilder.Sql("INSERT INTO dbo.Genres(Name) VALUES('Romantic')");
            migrationBuilder.Sql("INSERT INTO dbo.Genres(Name) VALUES('Action')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

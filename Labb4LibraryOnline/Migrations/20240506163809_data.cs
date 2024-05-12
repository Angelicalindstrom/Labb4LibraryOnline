using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4LibraryOnline.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Customers", columns: ["CustomerName","CustomerAdress","CustomerMail","CustomerPhoneNumber","FavGenre"],
                values: new object[,]
            {
                { "Angelica", "Raholmvägen 16", "angelica@gmail.com", "0737775455", 1 },
                { "Kerstin", "Lotsvägen 5", "kerstin@gmail.com", "0726675655", 1 },
                { "Reidar", "Norrgatan 88", "reidar@gmail.com", "0756444555", 1 },
            }
            );

            migrationBuilder.InsertData(table: "Books", columns: ["BookTitle", "BookAuthor", "BookGenre", "NumberOfCopies"],
               values: new object[,]
           {
                { "Skattkammarön ", "Robert Louis Stevenson", 0, 4 },
                { "Harry Potter", "J.K. Rowling", 1, 25 },
                { "The Shining", "Stephen King", 3,14 },
                { "Da Vinci-koden", "Dan Brown", 4, 20 },
                { "Dune", "Frank Herbert", 7,6 },
                { "The Fault in Our Stars", "John Green", 6, 10 },
                { "The Underground Railroad", "Colson Whitehead", 2,3 },
                { "Gone Girl", "Gillian Flynn", 5, 25 },
           }
           );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

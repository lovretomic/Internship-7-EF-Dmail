using Dmail.Domain.Factories;
using Dmail.Presentation.Helpers;

Writer.PrintHeader();
Console.WriteLine("PRIJAVA U SUSTAV");
Console.WriteLine("1 - Prijava (postojeci korisnici)");
Console.WriteLine("2 - Registracija (novi korisnik)");

var dbContext = DbContextFactory.GetDbContext();

var users = dbContext.Users.Where(x => x.FirstName == "Lovre");
var users1 = users.Where(x => x.Email == "tomiclovre05@gmail.com").ToList();

var a = 5;
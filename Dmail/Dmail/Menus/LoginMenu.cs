using Dmail.Domain.Enums;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Domain.UserData;
using Dmail.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
    public class LoginMenu
    {
        public void Open()
        {
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            Writer.PrintHeader();
            Console.WriteLine("1 - Prijava (postojeci korisnici)");
            Console.WriteLine("2 - Registracija (novi korisnik)");
            Console.WriteLine("0 - Napusti aplikaciju");

            string email, password, repeatedPassword, captcha, repeatedCaptcha, firstName, lastName;
            switch(Reader.ReadNumber())
            {
                case 1:
                    email = Reader.ReadString("Email:");
                    password = Reader.ReadString("Lozinka:");

                    var user = userRepository.GetByLoginData(email, password);

                    if (user is null)
                    {
                        Writer.PrintError("Ne postoji korisnik s navedenim podacima. Pripremam novi unos...");
                        System.Threading.Thread.Sleep(3000);

                        Open();
                    }
                    else
                    {
                        Console.WriteLine("Prijava uspjesna! Otvaram glavni izbornik...");
                        System.Threading.Thread.Sleep(2000);

                        var mainMenu = new MainMenu();
                        mainMenu.Open(user);
                    }
                    break;
                case 2:
                    firstName = Reader.ReadString("Ime:");
                    lastName = Reader.ReadString("Prezime:");
                    email = GetEmail();
                    password = Reader.ReadString("Lozinka:");
                    repeatedPassword = Reader.ReadString("Ponovljena lozinka:");
                    captcha = Generator.NewCaptcha();
                    Console.WriteLine($"Ponovite sljedeci izraz: {captcha}");
                    repeatedCaptcha = Reader.ReadString("Ponovljeni izraz:");

                    if(!userRepository.EmailIsUnique(email))
                    {
                        Writer.PrintError("Vec postoji korisnik s tom email adresom! Pripremam novi unos...");
                        System.Threading.Thread.Sleep(3000);
                        Open();
                    }

                    if(password == repeatedPassword && captcha == repeatedCaptcha)
                    {
                        var newUser = new Data.Entities.Models.User(firstName, lastName, email, password);
                        var result = userRepository.Add(newUser);

                        if (result is ActionStatus.Success) Console.WriteLine("Korisnik uspjesno dodan!");
                        else Writer.PrintError("Doslo je do problema prilikom dodavanja korisnika. Korisnik nije dodan.");
                        System.Threading.Thread.Sleep(3000);
                        Open();
                    }
                    break;
                default:
                    Console.WriteLine("Dovidenja! Zatvaram aplikaciju...");
                    System.Threading.Thread.Sleep(2000);
                    return;
                    break;
            }
        }

        private string GetEmail()
        {
            string email;
            do
            {
                email = Reader.ReadString("Email:");
                if (!Checker.EmailIsValid(email)) Writer.PrintInputError("Uneseni email nije valjan! Unesi novi mail.");

            } while (!Checker.EmailIsValid(email));
            return email;
        }
    }
}

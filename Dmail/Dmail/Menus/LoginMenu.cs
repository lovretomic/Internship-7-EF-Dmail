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
            string email, password, repeatedPassword, captcha, repeatedCaptcha, firstName, lastName;
            switch(Reader.ReadNumber())
            {
                case 1:
                    email = Reader.ReadString("Email:");
                    password = Reader.ReadString("Lozinka:");

                    var user = userRepository.GetByLoginData(email, password);

                    if (user is null)
                    {
                        Writer.PrintError("Ne postoji korisnik s navedenim podacima.");
                        Open();
                    }
                    else
                    {
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

                    if(password == repeatedPassword && captcha == repeatedCaptcha)
                    {
                        var newUser = new Data.Entities.Models.User(firstName, lastName, email, password);
                        var result = userRepository.Add(newUser);

                        if (result is ActionStatus.Success) Console.WriteLine("Korisnik uspjesno dodan!");
                        else Console.WriteLine("Doslo je do problema prilikom dodavanja korisnika. Korisnik nije dodan.");
                        Open();
                    }
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

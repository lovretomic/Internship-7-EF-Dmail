using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Helpers
{
    public static class Checker
    {
        public static bool EmailIsValid(string email)
        {
            if (!email.Contains('@') || !email.Contains('.')) return false;

            var splittedEmail = new List<string>();

            splittedEmail.Add(email.Substring(0, email.IndexOf('@')));
            splittedEmail.Add(email.Substring(email.IndexOf('@') + 1, email.IndexOf('.') - email.IndexOf('@') - 1));
            splittedEmail.Add(email.Substring(email.IndexOf('.') + 1, email.Length - email.IndexOf('.') - 1));

            return splittedEmail[0].Length >= 1 && splittedEmail[1].Length >= 2 && splittedEmail[2].Length >= 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Helpers
{
    public static class Generator
    {
        public static string NewCaptcha()
        {
            Random r = new Random();
            string captcha = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 10; i++)
            {
                captcha += chars[r.Next(0, chars.Length)];
            }
            return captcha;
        }
    }
}

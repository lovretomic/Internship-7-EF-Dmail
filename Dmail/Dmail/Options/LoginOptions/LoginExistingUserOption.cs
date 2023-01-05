using Dmail.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Options.LoginOptions
{
    public class LoginExistingUserOption : IOption
    {
        public string Name { get; set; }
        public void Open() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Abstractions
{
    public interface IOption
    {
        string Name { get; set; }
        void Open();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Abstractions
{
    public interface IScreen
    {
        public string Name { get; set; }
        public List<IOption> Options { get; set; }
    }
}

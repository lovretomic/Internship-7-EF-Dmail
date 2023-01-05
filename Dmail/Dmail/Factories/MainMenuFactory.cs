using Dmail.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IOption> CreateActions()
        {
            var actions = new List<IOption>
            {
                // Actions
            };

            return actions;
        }
    }
}

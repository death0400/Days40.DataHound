using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public class ConsoleLog : ILogger
    {
        public Action<string> Onlog { get; set; } = Console.WriteLine;

    }
}

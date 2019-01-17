using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public interface ILogger
    {
        Action<string> Onlog { get; set; }
    }
}

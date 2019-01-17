using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public interface IMapSetting<T1, T2>
    {
        Dictionary<Func<T1, T2, bool>, string> MapMsg { get; set; }
        void SetFailedMsg(string msg);
        void SetSuccessMsg(string msg);
    }
}

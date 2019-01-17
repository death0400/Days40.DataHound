using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public class Map<T1,T2>
    {
        public Func<T1, T2, bool> Check { get; set; }
        public MapSetting<T1, T2> Handler { get; set; }

        public static Map<T1, T2> GetMap(Func<T1, T2, bool> func)
        {
            var map = new Map<T1, T2>();
            map.Check = func;
            map.Handler = new MapSetting<T1, T2>();
            return map;
        }
    }
}

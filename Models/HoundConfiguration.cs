using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public class HoundConfiguration<T1, T2>
    {
        public List<Map<T1, T2>> maps { get; set; } = new List<Map<T1, T2>>();

        public MapSetting<T1, T2> AddMap(Func<T1, T2, bool> func)
        {
            var map = Map<T1, T2>.GetMap(func);
            map.Handler = new MapSetting<T1, T2>();
            maps.Add(map);
            return map.Handler;
        }
    }
}

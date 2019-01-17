using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Models
{
    public class MapSetting<T1, T2>
    {
        public Func<T1, T2, string> FailedMsgHandler { get; set; } =(t1,t2)=>"";
        public Func<T1, T2, string> SuccessMsgHandler { get; set; }=(t1,t2)=>"";



        public MapSetting<T1, T2> SetFailedMsg(string msg)
        {
            FailedMsgHandler += (t1, t2) => msg;
            return this;
        }
        public MapSetting<T1, T2> SetFailedMsg(Func<T1,T2,string> func)
        {
            if (FailedMsgHandler == null)
                FailedMsgHandler = func;
            else
                FailedMsgHandler += func;
            return this;
        }
        public MapSetting<T1, T2> SetSuccessMsg(string msg)
        {
            SuccessMsgHandler += (t1, t2) => msg;
            return this;
        }
        public MapSetting<T1, T2> SetSuccessMsg(Func<T1, T2, string> func)
        {
            if (SuccessMsgHandler == null)
                SuccessMsgHandler = func;
            else
                SuccessMsgHandler += func;
            return this;
        }
    }
}

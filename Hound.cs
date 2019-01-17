using Days40.DataHound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Days40.DataHound
{
    public class Hound<T1, T2>
    {
        private HoundConfiguration<T1, T2> config;
        private readonly IEnumerable<ILogger> loggers;
        public Hound(Action<HoundConfiguration<T1, T2>> compare,IEnumerable<ILogger> loggers)
        {
            this.loggers = loggers;
            config = new HoundConfiguration<T1, T2>();
            compare(config);
        }
        public bool Check(T1 t1, T2 t2)
        {
            var isAllPass = true;
            foreach (var map in config.maps)
            {
                var isPass = map.Check(t1, t2);
                foreach (var logger in loggers)
                {
                    var asd = map.Handler;
                    logger.Onlog?.Invoke(isPass ? map.Handler.SuccessMsgHandler(t1, t2): map.Handler.FailedMsgHandler(t1, t2));
                }
                if (!isPass)
                    isAllPass = false;
            }
            return isAllPass;
        }
    }
}

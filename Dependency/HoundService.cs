using Autofac;
using Days40.DataHound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days40.DataHound.Dependency
{
    public static class HoundService
    {
        private static ContainerBuilder containerBuilder;
        static HoundService()
        {
            containerBuilder = new ContainerBuilder();
        }
        public static Hound<T1,T2> GetHound<T1,T2>()
        {
            return containerBuilder.Build().Resolve<Hound<T1, T2>>();
        }

        public static void AddLogger<T>() where T:ILogger
        {
            containerBuilder.RegisterType<T>().As<ILogger>();
        }

        public static void AddCompare<T1,T2>(Action<HoundConfiguration<T1, T2>> compare)
        {
            containerBuilder.Register<Hound<T1, T2>>(container => new Hound<T1, T2>(compare, container.Resolve<IEnumerable<ILogger>>()));
        }
    }
}

using PingPong.Application.DI;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Test
{
    public class BaseRepositoryTest
    {
        public readonly Injector _injector;
        public readonly Container _container;
        public BaseRepositoryTest()
        {
            _injector = new Injector();
            _container = new Container();
            _container = _injector.Config();            
        }
    }
}

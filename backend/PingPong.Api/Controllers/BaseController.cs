using PingPong.Application.DI;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PingPong.Api.Controllers
{
    public class BaseController : ApiController
    {
        public readonly Injector _injector;
        public readonly Container _container;

        public BaseController()
        {
            _injector = new Injector();
            _container = new Container();
            _container = _injector.Config();
        }
    }
}

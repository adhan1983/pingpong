using PingPong.Application.AppService;
using PingPong.Application.Interfaces;
using PingPong.Domain.Interfaces.Repositories;
using PingPong.Domain.Interfaces.Services;
using PingPong.Domain.Services;
using PingPong.Infra.Data.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Application.DI
{
    public class Injector
    {
        public Container Config()
        {
            var container = new Container();            

            container.Register<IPlayerService, PlayerService>(Lifestyle.Singleton);
            container.Register<IPlayerRepository, PlayerRepository>(Lifestyle.Singleton);
            container.Register<ISkillLevelService, SkillLevelService>(Lifestyle.Singleton);
            container.Register<ISkillLevelRepository, SkillLevelRepository>(Lifestyle.Singleton);
            container.Register<ISkillLevelAppService, SkillLevelAppService>(Lifestyle.Singleton);
            container.Register<IPlayerAppService, PlayerAppService>(Lifestyle.Singleton);
            
            return container;
        }
    }
}

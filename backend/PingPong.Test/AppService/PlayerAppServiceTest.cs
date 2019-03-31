using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Application.DTOs;
using PingPong.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Test.AppService
{
    [TestClass]
    public class PlayerAppServiceTest : BaseRepositoryTest
    {
        private readonly IPlayerAppService _playerAppService;
        public PlayerAppServiceTest()
        {
            _playerAppService = _container.GetInstance<IPlayerAppService>();
        }

        [TestMethod]
        public void GetPlayers()
        {
            List<PlayerDTO> playersDTO = _playerAppService.GetPlayers();

            if (playersDTO != null)
            {
            }
        }

        [TestMethod]
        public void InsertPlayer()
        {
            try
            {
                PlayerDTO _playerDTO = new PlayerDTO()
                {
                    FirstName = "Carlos",
                    LastName = "Miranda",
                    Age = 36,
                    SkillLevelId = 1,
                    Email = "carlos.miranda@gmail.com"
                };

                var status = _playerAppService.InsertPlayer(_playerDTO);

                Assert.AreEqual(status, true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void UpDatePlayer()
        {
            try
            {
                PlayerDTO _playerDTO = new PlayerDTO()
                {
                    Id = 2,
                    FirstName = "Carloooooo6666ooooosss",
                    LastName = "Mirandwwa",                    
                    SkillLevelId = 2,
                    Email = "carlos.miranda@yahoo.com.br"
                };

                var status = _playerAppService.UpDatePlayer(_playerDTO);

                Assert.AreEqual(status, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [TestMethod]
        public void DeletePlayer()
        {
            try
            {               
                bool status = _playerAppService.DeletePlayer(3);

                Assert.AreEqual(status, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

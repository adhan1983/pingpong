using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Application.DI;
using PingPong.Domain.Entities;
using PingPong.Domain.Interfaces.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Test.Repositories
{
    [TestClass]
    public class PlayerRepositoryTest : BaseRepositoryTest
    {

        private readonly IPlayerRepository _playerRepository;
        public PlayerRepositoryTest()
        {
            _playerRepository = _container.GetInstance<IPlayerRepository>();
        }

        [TestMethod]
        public void GetPlayers()
        {
            IEnumerable<Player> players = _playerRepository.GetPlayers();

            Assert.IsTrue(players.Count() > 0, "There is at least one player in Database");
        }

        [TestMethod]
        public void GetPlayersbyIdTest()
        {           
            Player _player = _playerRepository.GetById(17);

            Assert.IsTrue(_player != null && _player.FisrtName == "Angelina" && _player.LastName == "Jolie", "There is at least one player in Database");
        }

        [TestMethod]
        public void Insert()
        {
            try
            {
                Player _player1 = new Player()
                {
                    FisrtName = "Brad",
                    LastName = "Pitt",
                    Age = 29,
                    SkillLevelId = 1,
                    Email = "brad.pitt@gmail.com"
                };
                bool status = _playerRepository.Add(_player1);
                Assert.IsTrue(status, "The Player " + _player1.FisrtName + " was added!");

                Player _player2 = new Player()
                {
                    FisrtName = "Angelina",
                    LastName = "Jolie",
                    Age = 23,
                    SkillLevelId = 2,
                    Email = "angelina.jolie@yahoo.com"
                };
                status = _playerRepository.Add(_player2);
                Assert.IsTrue(status, "The Player " + _player2.FisrtName + " was added!");

                Player _player3 = new Player()
                {
                    FisrtName = "Aubrey",
                    LastName = "Drake",
                    Age = 27,
                    SkillLevelId = 1,
                    Email = "aubrey.drake@gmail.com"
                };
                status = _playerRepository.Add(_player3);
                Assert.IsTrue(status, "The Player " + _player3.FisrtName + " was added!");

                Player _player4 = new Player()
                {
                    FisrtName = "Alanis",
                    LastName = "Morissete",
                    Age = 24,
                    SkillLevelId = 3,
                    Email = "alanis.morissete@yahoo.com"
                };
                status = _playerRepository.Add(_player4);
                Assert.IsTrue(status, "The Player " + _player4.FisrtName + " was added!");

                Player _player5 = new Player()
                {
                    FisrtName = "Sarah",
                    LastName = "McLachlan",
                    Age = 29,
                    SkillLevelId = 4,
                    Email = "sarah.mcLachlan@hotmail.com"
                };
                status = _playerRepository.Add(_player5);
                Assert.IsTrue(status, "The Player " + _player5.FisrtName + " was added!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [TestMethod]
        public void Update()
        {
            Player _player = _playerRepository.GetById(17);
            _player.FisrtName = "Angel";
            _player.Age = null;
            _playerRepository.Update(_player);
        }

        [TestMethod]
        public void Delete()
        {
            int playerId = 0;
            
            Player _player = _playerRepository.GetById(playerId);

            bool status = _playerRepository.Remove(_player);

            Assert.IsTrue(status, "The Player " + _player.FisrtName  + " was deleted!");            
        }
    }
}

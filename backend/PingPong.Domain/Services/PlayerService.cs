using System;
using System.Collections.Generic;
using PingPong.Domain.Entities;
using PingPong.Domain.Interfaces.Repositories;
using PingPong.Domain.Interfaces.Services;

namespace PingPong.Domain.Services
{
    public class PlayerService : ServiceBase<Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
            :base(playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public List<Player> GetPlayers()
        {
            return _playerRepository.GetPlayers();
        }
    }
}

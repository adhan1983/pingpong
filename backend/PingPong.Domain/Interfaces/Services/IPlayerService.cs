using PingPong.Domain.Entities;
using System.Collections.Generic;

namespace PingPong.Domain.Interfaces.Services
{
    public interface IPlayerService : IServiceBase<Player>
    {
        List<Player> GetPlayers();
    }
}

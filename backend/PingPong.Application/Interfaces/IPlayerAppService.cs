using PingPong.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Application.Interfaces
{
    public interface IPlayerAppService
    {
        List<PlayerDTO> GetPlayers();
        PlayerDTO GetPlayer(int id);
        bool InsertPlayer(PlayerDTO playerDTO);
        bool UpDatePlayer(PlayerDTO playerDTO);
        bool DeletePlayer(int playerId);
    }
}

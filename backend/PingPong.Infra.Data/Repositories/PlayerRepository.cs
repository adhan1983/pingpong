using PingPong.Domain.Entities;
using PingPong.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Infra.Data.Repositories
{
    public class PlayerRepository : RespositoryBase<Player>, IPlayerRepository
    {
        public List<Player> GetPlayers()
        {
            var players = Db.Set<Player>().Include("SkillLevel").ToList();

            return players;
        }
    }
}

using PingPong.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.Application.DTOs;
using PingPong.Domain.Entities;
using PingPong.Domain.Interfaces.Services;

namespace PingPong.Application.AppService
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IPlayerService _playerService;
        public PlayerAppService(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public PlayerDTO GetPlayer(int id)
        {
            PlayerDTO _playerDTO;
            try
            {
                var player = _playerService.GetById(id);
                if (player != null) {
                    _playerDTO = new PlayerDTO()
                    {
                        FirstName = player.FisrtName,
                        LastName = player.LastName,
                        Age = player.Age,
                        SkillLevelId = player.SkillLevelId,
                        SkillLevel = new SkillLevelDTO() { Id = player.SkillLevel.Id, Name = player.SkillLevel.Name }                        
                    };
                }
                else
                    _playerDTO = new PlayerDTO();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _playerDTO;
        }
        public List<PlayerDTO> GetPlayers()
        {
            List<PlayerDTO> _playersDTOs = new List<PlayerDTO>();

            try
            {
                Func<Player, PlayerDTO> _fnParse = delegate (Player p)
                {
                    var _playerDTO = new PlayerDTO()
                    {
                        Id = p.Id,
                        FirstName = p.FisrtName,
                        LastName = p.LastName,
                        Age = p.Age,
                        Email = p.Email,
                        SkillLevelId = p.SkillLevelId,
                        SkillLevel = new SkillLevelDTO()
                        {
                            Id = p.SkillLevel.Id,
                            Name = p.SkillLevel.Name
                        }
                    };

                    return _playerDTO;
                };

                _playersDTOs = _playerService.GetPlayers().
                    Select(p => _fnParse(p)).
                    ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _playersDTOs;
        }
        public bool InsertPlayer(PlayerDTO playerDTO)
        {
            bool status = false;

            try
            {
                Player _player = new Player()
                {
                    FisrtName = playerDTO.FirstName,
                    LastName = playerDTO.LastName,
                    Age = playerDTO.Age,
                    SkillLevelId = playerDTO.SkillLevelId,
                    Email = playerDTO.Email
                };

                status = _playerService.Add(_player);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return status;
        }
        public bool UpDatePlayer(PlayerDTO playerDTO)
        {
            bool status = false;
            try
            {             
                Player _player = _playerService.GetById(playerDTO.Id);

                _player.FisrtName = playerDTO.FirstName;
                _player.LastName = playerDTO.LastName;
                _player.SkillLevelId = playerDTO.SkillLevelId;
                _player.Age = playerDTO.Age;
                _player.Email = playerDTO.Email;

                status = _playerService.Update(_player);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return status;
        }
        public bool DeletePlayer(int playerId)
        {
            bool status = false;

            try
            {
                Player _player = _playerService.GetById(playerId);

                status = _playerService.Remove(_player);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return status;
        }        
    }
}

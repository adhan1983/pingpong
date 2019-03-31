using PingPong.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong.Application.DTOs;
using PingPong.Domain.Interfaces.Services;
using PingPong.Domain.Entities;

namespace PingPong.Application.AppService
{
    public class SkillLevelAppService : ISkillLevelAppService
    {
        private readonly ISkillLevelService _skillLevelService;
        public SkillLevelAppService(ISkillLevelService skillLevelService)
        {
            _skillLevelService = skillLevelService;
        }

        public List<SkillLevelDTO> GetSkillLevels()
        {
            List<SkillLevelDTO> skillLevelDTO;
            try
            {
                Func<SkillLevel, SkillLevelDTO> _fnParse = delegate (SkillLevel sk)
                {
                    var _skillLevelDTO = new SkillLevelDTO()
                    {
                        Id = sk.Id,
                        Name = sk.Name                       
                    };

                    return _skillLevelDTO;
                };

                skillLevelDTO = _skillLevelService.
                    GetAll().
                    Select(sk => _fnParse(sk)).
                    ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return skillLevelDTO;
        }
    }
}

using PingPong.Application.DTOs;
using PingPong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Application.Interfaces
{
    public interface ISkillLevelAppService
    {
        List<SkillLevelDTO> GetSkillLevels();
    }
}

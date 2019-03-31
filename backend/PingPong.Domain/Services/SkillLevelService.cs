using PingPong.Domain.Entities;
using PingPong.Domain.Interfaces.Repositories;
using PingPong.Domain.Interfaces.Services;

namespace PingPong.Domain.Services
{
    public class SkillLevelService: ServiceBase<SkillLevel>, ISkillLevelService
    {
        private readonly ISkillLevelRepository _skillLevelRepository;

        public SkillLevelService(ISkillLevelRepository skillLevelRepository)
            :base(skillLevelRepository)
        {
            _skillLevelRepository = skillLevelRepository;
        }
    }
}

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
    public class SkillLevelAppServiceTest : BaseRepositoryTest
    {
        private readonly ISkillLevelAppService _skillLevelAppService;
        public SkillLevelAppServiceTest()
        {
            _skillLevelAppService = _container.GetInstance<ISkillLevelAppService>(); ;
        }

        [TestMethod]
        public void GetSkillLevels()
        {
            List<SkillLevelDTO> SkillLevelDTOs = _skillLevelAppService.GetSkillLevels();

            Assert.IsTrue(SkillLevelDTOs != null && SkillLevelDTOs.Count > 0 , "There is at least one skillLevel in Database");
        }

        [TestMethod]
        public void VerifyIfExistAllSkillLevels()
        {
            List<SkillLevelDTO> SkillLevelDTOs = _skillLevelAppService.GetSkillLevels();

            if (SkillLevelDTOs.Count > 0)
            {
                foreach (var skillLevel in SkillLevelDTOs)
                {
                    if (skillLevel.Name == "Beginner" || skillLevel.Name == "Intermediate" || skillLevel.Name == "Advanced" || skillLevel.Name == "Expert")                    
                        Assert.IsTrue(true, "The Skill Level " + skillLevel.Name + " exist in Database");
                    
                    else
                        Assert.IsFalse(true, "The Skill Level " + skillLevel.Name + " does not exist in Database");
                } 
            }
        }
        
    }
}

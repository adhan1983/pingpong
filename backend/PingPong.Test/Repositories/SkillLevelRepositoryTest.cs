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
    public class SkillLevelRepositoryTest : BaseRepositoryTest
    {
        ISkillLevelRepository _skillLevelRepository;

        public SkillLevelRepositoryTest()            
        {
            _skillLevelRepository = _container.GetInstance<ISkillLevelRepository>();
        }

        [TestMethod]
        public void GetSkillLevels()
        {
            var skillLevels =  _skillLevelRepository.GetAll();

            Assert.IsTrue(skillLevels.Count() > 0, "There is at least one player in Database");
        }

        [TestMethod]
        public void Insert()
        {
            try
            {                
                List<SkillLevel> skillLevels = new List<SkillLevel>();

                SkillLevel _skillLevel1 = new SkillLevel() { Name = "Beginner" };
                skillLevels.Add(_skillLevel1);
                SkillLevel _skillLevel2 = new SkillLevel() { Name = "Intermediate" };
                skillLevels.Add(_skillLevel2);
                SkillLevel _skillLevel3 = new SkillLevel() { Name = "Advanced" };
                skillLevels.Add(_skillLevel3);
                SkillLevel _skillLevel4 = new SkillLevel() { Name = "Expert" };
                skillLevels.Add(_skillLevel3);

                bool status = false;

                foreach (SkillLevel skillLevel in skillLevels)
                {                   
                   status = _skillLevelRepository.Add(skillLevel);
                   Assert.IsTrue(status, "The skill level " + skillLevel.Name + "was created successfully");                    
                }                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

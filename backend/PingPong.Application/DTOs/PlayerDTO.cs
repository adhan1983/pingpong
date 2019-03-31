using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Application.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public int SkillLevelId { get; set; }
        public SkillLevelDTO SkillLevel { get; set; }
    }
}

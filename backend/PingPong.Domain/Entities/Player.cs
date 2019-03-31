using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Domain.Entities
{    
    public class Player
    {
        public int Id { get; set; }        
        public string FisrtName { get; set; }        
        public string LastName { get; set; }
        public int? Age { get; set; }        
        public string Email { get; set; }

        [ForeignKey("SkillLevel")]
        public int SkillLevelId { get; set; }
        public SkillLevel SkillLevel { get; set; }        
    }
}

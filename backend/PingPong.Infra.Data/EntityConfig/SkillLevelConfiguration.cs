using PingPong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Infra.Data.EntityConfig
{
    public class SkillLevelConfiguration : EntityTypeConfiguration<SkillLevel>
    {
        public SkillLevelConfiguration()
        {
            HasKey(sk => sk.Id);
            Property(skl => skl.Name)
                .IsRequired()
                .HasMaxLength(150);            
        }
    }
}

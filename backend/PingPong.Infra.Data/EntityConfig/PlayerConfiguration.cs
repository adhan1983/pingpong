using PingPong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Infra.Data.EntityConfig
{
    public class PlayerConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.FisrtName)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(300);

            Property(p => p.Age)
                .IsOptional();            
        }
    }
}

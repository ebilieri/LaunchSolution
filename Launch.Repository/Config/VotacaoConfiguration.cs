using Launch.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Repository.Config
{
    public class VotacaoConfiguration : IEntityTypeConfiguration<Votacao>
    {
        public void Configure(EntityTypeBuilder<Votacao> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.CandidatoId).IsRequired();

            builder.Property(u => u.DataVotacao).IsRequired();            
        }
    }
}

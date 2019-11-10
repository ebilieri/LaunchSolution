using Launch.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Launch.Repository.Config
{
    public class VotacaoDiariaConfiguration : IEntityTypeConfiguration<VotacaoDiaria>
    {
        public void Configure(EntityTypeBuilder<VotacaoDiaria> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.CandidatoId).IsRequired();

            builder.Property(u => u.DataVotacao).IsRequired();

            builder.Property(u => u.TotalVotosDia).IsRequired();
        }
    }
}

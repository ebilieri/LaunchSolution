using Launch.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Launch.Repository.Config
{
    public class VotacaoSemanalConfiguration : IEntityTypeConfiguration<VotacaoSemanal>
    {
        public void Configure(EntityTypeBuilder<VotacaoSemanal> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.CandidatoId).IsRequired();

            builder.Property(u => u.NumeroSemana).IsRequired();

            builder.Property(u => u.TotalVotosSemana).IsRequired();
        }
    }
}

using Launch.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Launch.Repository.Config
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Property(u => u.ImagemUrl).HasMaxLength(400);

            builder.Property(u => u.Senha).IsRequired().HasMaxLength(400);

            builder.Property(u => u.ConfirmaSenha).HasMaxLength(400);

            //Mapeamento Relacionamento Canditado - Votacao
            builder.HasMany(u => u.VotosCandidato)
                .WithOne(p => p.Candidato);
                //.HasForeignKey(p => p.CandidatoId);

            // Mapeamento Relacionamento Canditado - VotacaoDiaria
            builder.HasMany(u => u.VotosDiarioCandidato)
                .WithOne(p => p.Candidato);
                //.HasForeignKey(p => p.CandidatoId);

            // Mapeamento Relacionamento Canditado - VotacaoSemanal
            builder.HasMany(u => u.VotosSemanalCandidato)
                .WithOne(p => p.Candidato);
                //.HasForeignKey(p => p.CandidatoId);
        }
    }
}

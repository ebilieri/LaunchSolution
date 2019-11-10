using Launch.Domain.Entidades;
using Launch.Repository.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Launch.Repository.Contexto
{
    public class LaunchContexto : DbContext
    {
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Votacao> Votacao { get; set; }
        public DbSet<VotacaoDiaria> VotacaoDiaria { get; set; }
        public DbSet<VotacaoSemanal> VotacaoSemanal { get; set; }
       

        public LaunchContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapeamento das entidades
            modelBuilder.ApplyConfiguration(new CandidatoConfiguration());
            modelBuilder.ApplyConfiguration(new VotacaoConfiguration());
            modelBuilder.ApplyConfiguration(new VotacaoDiariaConfiguration());
            modelBuilder.ApplyConfiguration(new VotacaoSemanalConfiguration());           

            base.OnModelCreating(modelBuilder);
        }
    }
}

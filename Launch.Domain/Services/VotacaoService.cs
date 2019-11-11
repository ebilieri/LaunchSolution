using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Contratos.IServices;
using Launch.Domain.Entidades;
using System;
using System.Globalization;
using System.Transactions;

namespace Launch.Domain.Services
{
    public class VotacaoService : ServiceBase<Votacao>, IVotacaoService
    {
        private readonly IVotacaoRepositorio _votacaoRepositorio;
        private readonly IVotacaoDiariaRepositorio _votacaoDiariaRepositorio;
        private readonly IVotacaoSemanalRepositorio _votacaoSemanalRepositorio;
        public VotacaoService(IVotacaoRepositorio votacaoRepositorio,
                              IVotacaoDiariaRepositorio votacaoDiariaRepositorio,
                              IVotacaoSemanalRepositorio votacaoSemanalRepositorio) : base(votacaoRepositorio)
        {
            _votacaoRepositorio = votacaoRepositorio;
            _votacaoDiariaRepositorio = votacaoDiariaRepositorio;
            _votacaoSemanalRepositorio = votacaoSemanalRepositorio;
        }

        public override void Adicionar(Votacao entity)
        {
            DateTime inicioVotacao = Convert.ToDateTime($"{ DateTime.Now.Date.ToShortDateString()} 10:00");
            DateTime fimVotacao = Convert.ToDateTime($"{ DateTime.Now.Date.ToShortDateString()} 12:00");
            if (DateTime.Now >= inicioVotacao && DateTime.Now <= fimVotacao)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    entity.DataVotacao = DateTime.Now;
                    base.Adicionar(entity);

                    if (entity.Id > 0)
                    {
                        // Votos diario
                        AdicionarVotacaoDiaria(entity);
                        // Votos semanal
                        AdicionarVotacaoSemanal(entity);
                    }

                    transactionScope.Complete();
                }
            }
            else
            {
                entity.AdicionarMensagem("Votação encerrada");
            }
        }

        public VotacaoDiaria BuscarReiDoAlmoco()
        {
            return _votacaoDiariaRepositorio.BuscarReidoAlmoco();
        }

        public int BuscarTotalVotosDiario(int candidatoId)
        {
            var votosDiario = _votacaoDiariaRepositorio.BuscarVotoCandidato(candidatoId, DateTime.Now.Date);
            return votosDiario == null ? 0 : votosDiario.TotalVotosDia;
        }

        private void AdicionarVotacaoDiaria(Votacao entity)
        {
            var votacaoDiaria = _votacaoDiariaRepositorio.BuscarVotoCandidato(entity.CandidatoId, entity.DataVotacao.Date);

            if (votacaoDiaria == null)
            {
                votacaoDiaria = new VotacaoDiaria
                {
                    CandidatoId = entity.CandidatoId,
                    DataVotacao = DateTime.Now.Date,
                    TotalVotosDia = 1
                };

                _votacaoDiariaRepositorio.Adicionar(votacaoDiaria);
            }
            else
            {
                votacaoDiaria.TotalVotosDia++;

                _votacaoDiariaRepositorio.Atualizar(votacaoDiaria);
            }
        }

        private void AdicionarVotacaoSemanal(Votacao entity)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int numeroSemana = ciCurr.Calendar.GetWeekOfYear(entity.DataVotacao, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var votacaoSemanal = _votacaoSemanalRepositorio.BuscarVotoCandidato(entity.CandidatoId, numeroSemana);

            if (votacaoSemanal == null)
            {
                votacaoSemanal = new VotacaoSemanal
                {
                    CandidatoId = entity.CandidatoId,
                    NumeroSemana = numeroSemana,
                    TotalVotosSemana = 1
                };

                _votacaoSemanalRepositorio.Adicionar(votacaoSemanal);
            }
            else
            {
                votacaoSemanal.TotalVotosSemana++;

                _votacaoSemanalRepositorio.Atualizar(votacaoSemanal);
            }
        }
    }
}

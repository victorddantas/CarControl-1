﻿ using CarControl.Domain;
using CarControl.Infrastructure.Repositories.Interface;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CarControl.Infrastructure.Repositories
{
    public class MovimentoRepository : BaseRepository<Movimento>, IMovimentoRepository
    {

        public MovimentoRepository(CarControlContext context) : base(context)
        {

        }

      
        #region  CRUD

        public Movimento RegistrarEntrada(Movimento movimento)
        {
            _dbset.Add(movimento);
            _context.SaveChanges();

            return movimento;
        }

        public Movimento RegistrarSaida(Movimento movimento)
        {
            var vagaCadastrada = _dbset.Where(p => p.IdVaga == movimento.IdVaga && p.HrSaida == null).SingleOrDefault();

            if (vagaCadastrada == null)
            {
                return null;
            }

            vagaCadastrada.Atualiza(movimento);

            _context.SaveChanges();

            return vagaCadastrada;

        }
        public IEnumerable<Movimento> ConsultaSeTemMovimento(int idVeiculo)
        {
            var movimento = _dbset.Where(p => p.IdVeiculo == idVeiculo).ToList() ?? null;

            return movimento;
        }

        public IEnumerable<Movimento> ConsultaSeTemMovimento(Movimento movimento)
        {
            var movimentoVeiculo = _dbset.Where(p => p.IdVeiculo == movimento.IdVeiculo && p.DtSaida == null).ToList() ?? null;

            return movimentoVeiculo;
        }


        #endregion
    }
}

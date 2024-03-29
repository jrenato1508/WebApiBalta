﻿using BaltaIO.Business.Interface;
using BaltaIO.Business.Models;
using BaltaIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Data.Repository
{
    public class IBGERepository : Repository<IBGE> , IibgeRepository
    {
        public IBGERepository(BaltaDbContext db) : base(db)
        {
        }

        public async Task<IBGE> ObtermunicioPorID(int id)
        {
            return await _dbContext.IBGE.AsNoTracking().FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<IBGE> ObterMunicipioPorCodigoIbge(string codigo)
        {
            // precisamos alterar o ID da class IBGE para código, e fazer a alteração no novo banco.
            return await _dbContext.IBGE.AsNoTracking().FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        public async Task<IEnumerable<IBGE>> ObterMunicipioPorNome(string nomeCidade)
        {
            return await Buscar(c => c.Cidade == nomeCidade);
        }

        public async Task<IEnumerable<IBGE>> ObterMunicipiosPorUf(string uf)
        {
            return await Buscar(c => c.UF == uf);
        }

    }
}

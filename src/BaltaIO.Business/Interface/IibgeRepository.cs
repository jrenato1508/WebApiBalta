using BaltaIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Interface
{
    public interface IibgeRepository : IRepository<IBGE>
    {
        Task<IBGE> ObtermunicioPorID(int id);

        Task<IEnumerable<IBGE>> ObterMunicipioPorNome(string nome);

        Task<IBGE> ObterMunicipioPorCodigoIbge(string codigo);

        Task<IEnumerable<IBGE>> ObterMunicipiosPorUf(string uf);

    }
}

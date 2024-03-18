using BaltaIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Interface
{
    public interface IibgeService: IDisposable
    {
        Task Adicionar(IBGE muncicipio);
        Task Atualizar(IBGE muncicipio);

    }
}

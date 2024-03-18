using BaltaIO.Business.Interface;
using BaltaIO.Business.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Services
{
    public class IbgeServices : BaseService, IibgeService
    {

        private readonly IibgeRepository _ibgeRepository;
        public IbgeServices(INotificador notificador,
                            IibgeRepository ibgeRepository) : base(notificador)
        {
            _ibgeRepository = ibgeRepository;
        }

        public async Task Adicionar(IBGE municipio)
        {
            if (!ExecutarValidacao(new IbgeValidation(), municipio)) return;

            if(_ibgeRepository.Buscar(c => c.Codigo == municipio.Codigo).Result.Any())
            {
                Notificar("Já existe um municipio com o código informado.");
                return;
            }
            
            if(_ibgeRepository.Buscar(c=>c.UF == municipio.UF && c.Cidade == municipio.Cidade).Result.Any())
            {
                Notificar("Já exite uma cidade cadastrada para o estado informado");
            }

            await _ibgeRepository.Adicionar(municipio);
        }

        public async Task Atualizar(IBGE municipio)
        {
            if (!ExecutarValidacao(new IbgeValidation(), municipio)) return;

            if (_ibgeRepository.Buscar(c => c.Codigo == municipio.Codigo).Result.Any())
            {
                Notificar("Já existe um municipio com o código informado.");
                return;
            }

            await _ibgeRepository.Atualizar(municipio);
        }

        public void Dispose()
        {
            _ibgeRepository?.Dispose();
        }
    }
}

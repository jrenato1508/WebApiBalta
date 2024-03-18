using Asp.Versioning;
using AutoMapper;
using BaltaIO.Api.Controllers;
using BaltaIO.Api.Extensions;
using BaltaIO.Api.ViewModel_DTO;
using BaltaIO.Business.Interface;
using BaltaIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BaltaIO.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/IBGE")]
    public class IbgeController : MainController
    {
        private readonly IibgeRepository _IbgeRepository;
        private readonly IibgeService _IbgeService;
        private readonly IMapper _Mapper;
        public IbgeController(IibgeRepository ibge,
                              IibgeService bgeService,
                              IMapper mapper,
                              INotificador notificador) : base(notificador) 
        {
            _IbgeRepository = ibge;
            _IbgeService = bgeService;
            _Mapper = mapper;
        }

        [ClaimsAuthorize("Admin", "Admin")]
        [HttpGet("obter-Municipio-Por-Uf")]
        public async Task<IEnumerable<IbgeViewModel>> ObterMunicipiosPorUf(string uf)
        {
            var municipios = _Mapper.Map<IEnumerable<IbgeViewModel>>(await _IbgeRepository.ObterMunicipiosPorUf(uf));
            return municipios;
        }


        [ClaimsAuthorize("Admin", "Admin")]
        [HttpGet("obter-Municipio-Por-Id/{id:int}")]
        public async Task <IbgeViewModel> ObtermunicioPorID(int id)
        {
            var municipios = _Mapper.Map<IbgeViewModel>(await _IbgeRepository.ObtermunicioPorID(id));
            return municipios;
        }

        [ClaimsAuthorize("Admin", "Admin")]
        [HttpGet("obter-Municipio-Por-CodigoIbge")]
        public async Task<IbgeViewModel> ObterMunicipioPorCodigoIbge(string codioIbge)
        {
            var municipios = _Mapper.Map<IbgeViewModel>(await _IbgeRepository.ObterMunicipioPorCodigoIbge(codioIbge));
            return municipios;
        }

        [ClaimsAuthorize("Admin", "Admin")]
        [HttpGet("obter-Municipio-Por-Nome")]
        public async Task<IEnumerable<IbgeViewModel>> ObterMunicipioPorNome(string nome)
        {
            var municipios = _Mapper.Map<IEnumerable<IbgeViewModel>>(await _IbgeRepository.ObterMunicipioPorNome(nome));
            return municipios;
        }

        [ClaimsAuthorize("Admin", "Admin")]
        [HttpPost("Adicionar-Novo-Municipio")]
        public async Task<ActionResult<IbgeViewModel>> Adicionar(IbgeViewModel municipio) 
        {
            if(!ModelState.IsValid) return CustomResponde(ModelState);
            await _IbgeService.Adicionar(_Mapper.Map<IBGE>(municipio));
            return CustomResponde(municipio);
        }

        [ClaimsAuthorize("Admin", "Admin")]
        [HttpPut("Atualizar-Municipio")]
        public async Task<ActionResult<IbgeViewModel>> Atualizar(IbgeViewModel municipio)
        {
            if (!ModelState.IsValid) return CustomResponde(ModelState);
            await _IbgeService.Atualizar(_Mapper.Map<IBGE>(municipio));
            return CustomResponde(municipio);
        }
    }
}

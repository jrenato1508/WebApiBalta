using BaltaIO.Business.Interface;
using BaltaIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaltaIO.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController( INotificador notificador)
        {
            _notificador = notificador;
            
        }

        protected ActionResult CustomResponde(ModelStateDictionary modelState)
        {
            if(!ModelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponde();
        }

        protected ActionResult CustomResponde(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new { success = true,
                                Data = result });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState) 
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            
            foreach(var erro in erros)
            {
                var erroMsg = erro.Exception == null? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }

        protected void NotificarErro(string erroMsg)
        {
            _notificador.Handle(new Notificacao(erroMsg));
        }
    }
}

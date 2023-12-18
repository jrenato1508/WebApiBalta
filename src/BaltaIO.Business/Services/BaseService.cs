//using BaltaIO.Business.Interface;
//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BaltaIO.Business.Services
//{
//    public abstract class BaseService
//    {
//        private readonly INotificador _notificador;
//        protected BaseService(INotificador notificador)
//        {
//            _notificador = notificador;
//        }

//        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> 
//        {
//            var validator = validacao.Validate(entidade);

//            if (validator.IsValid) return true;

            
//            Notificar(validator);

//            return false;
//        }
//        protected void Notificar(ValidationResult validationResult)
//        {
//            foreach (var error in validationResult.Errors)
//                Notificar(error.ErrorMessage);
            
//        }

//        protected void Notificar(string mensagem)
//        { 
//            _notificador.Handle(new Notificacao(mensagem));
//        }
//    }
//}

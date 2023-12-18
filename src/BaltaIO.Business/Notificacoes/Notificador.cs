using BaltaIO.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        #region OBS
        /* _notificacoes será uma lista global que irá durar todo o request, nós iremos adicionar notificações aqui dentro durante
           todo o processo de validação. Essa lista será lançada e manipulada pelo metodo Handle.
           
        */
        #endregion
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            //Metodo Habdle adiciona as mensagens de notificações da lista
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        #region OBS 
        /*
         Como configuramos a injeção de dependencia de Notificador como Scoped na class de configuração DependencyInjectionConfig essa lista
         e metodo estará disponível durante toda a requisição. Podemos consultar mais informações sobre tipo de configuração em nossas anotações.
         */
        #endregion
        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}

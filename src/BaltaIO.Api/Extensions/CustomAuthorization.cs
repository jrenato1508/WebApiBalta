using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BaltaIO.Api.Extensions
{
    #region class ClaimsAuthorizeAttribute

    #region OBS
    /*
      Esse metodo é chamado toda vez que alguma action dentro da controller etiver decorada com o [ClaimsAuthorize("Type/nome Claim","ValuerClaim")]
      
      OBS: Note que ele passsa uma classe RequisitoClaimFilter como base. E lá classe RequisitoClaimFilter ele já recebe o nome/Type e valor da claim para
           realizar as validações no metodo OnAuthorization
     */
    #endregion
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
    #endregion




    #region class RequisitoClaimFilter
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
    #endregion

    #region class CustomAuthorization

    #region OBS
    /*
       Esse metodo recebe como parametro um contexto http, o tipo da claim(claimType) e valor da claim(claimVaule). Depois o metoto vai conferir se o usuário
       está autenticado(IsAuthenticated) e e depois verificar se o usuário possui alguma claim(User.Claims.Any) e se houver, confere se o Nome(type) e valor 
       da claim é igual o nome e valor da claim que está configurado em nosso metoto na controller.
     */
    #endregion
    public class CustomAuthorization
    {

        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
    #endregion

}

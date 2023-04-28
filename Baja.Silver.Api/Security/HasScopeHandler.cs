using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Baja.Silver.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirements>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirements requirements)
        {
            //If user does not have the scope claim, get out of here.

            if(!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirements.Issuer))
                return Task.CompletedTask;

            //Split the scopes string into an array
            var scopes = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirements.Issuer)
                .Value.Split(' ');
            
            //Succeed if the scope array contains the required scope
            if(scopes.Any(s => s == requirements.Scope))
                context.Succeed(requirements);

            return Task.CompletedTask;
        }
    }
}
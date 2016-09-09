using Microsoft.AspNetCore.Mvc.ModelBinding;
using PureBlack.Core;

namespace TruckWorld.MainSite.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddErrors(this ModelStateDictionary modelState, GenericResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                modelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpensesTracker.Identity.Areas.Identity.Pages.Account
{
    public class DiagnosticModel : PageModel
    {
        public IEnumerable<Claim> Claims { get; set; }
        public IRequestCookieCollection Cookies { get; set; }
        public string AccessToken { get; set; }

        public async Task OnGetAsync()
        {
            Claims = User.Claims;
            Cookies = Request.Cookies;
            AccessToken = await HttpContext.GetTokenAsync("access_token");
            //AuthenticationProperties = User.Identity.
        }
    }
}

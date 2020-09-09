using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.Identity.Data.Model;
using ExpensesTracker.Identity.Features.Users.Models;
using ExpenseTracker.Shared.ApiInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace ExpensesTracker.Identity.Features.Users
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "identity.schema")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
             UserManager<ApplicationUser> userManager,
             ILogger<UsersController> logger
            )
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Policy = "UserManager", AuthenticationSchemes = "identity.schema")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser.CreateUserRequest createUserRequest)
        {
            var user = new ApplicationUser { UserName = createUserRequest.Email, Email = createUserRequest.Email };
            var result = await _userManager.CreateAsync(user, createUserRequest.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return Ok(new ApiResult<CreateUser.CreateUserResponse>
                {
                    Data = new CreateUser.CreateUserResponse
                    {
                        Id = user.Id,
                        ConfirmEmailCode = code,
                        RequireConfirmedAccount = _userManager.Options.SignIn.RequireConfirmedAccount
                    }
                });
            }

            return BadRequest(new ApiResult<CreateUser.CreateUserResponse>
            {
                ApiErrors = result.Errors.Select(e => new ApiError
                {
                    Code = e.Code,
                    Message = e.Description
                }).ToArray()
            });
        }

        [HttpPost("{userId}/confirm-email")]
        //[Authorize(Policy = "UserManager", AuthenticationSchemes = "identity.schema")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string userId, [FromBody] ConfirmEmail.ConfirmEmailRequest createUserRequest)
        {
            if (userId == null || createUserRequest.Code == null)
            {
                return BadRequest("No UserId or Code Found in the Requets");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest($"Unable to load user with ID '{userId}'.");
            }

            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(createUserRequest.Code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            // Improve this logic
            var StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            if (result.Succeeded) {
                return Ok(StatusMessage);
            }
            return BadRequest(StatusMessage);
        }

    }


}

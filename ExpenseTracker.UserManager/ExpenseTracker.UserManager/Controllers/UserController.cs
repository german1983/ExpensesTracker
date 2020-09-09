using ExpenseTracker.Shared.ApiInterface;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker.UserManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                _logger.LogError(disco.Error);
                // Probably would be better to throw Exception and read from there
                return BadRequest(disco.Error);
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "usrManager",
                ClientSecret = "SuperSecretPassword",
                Scope = "identity identity.admin"
            });

            if (tokenResponse.IsError)
            {
                _logger.LogError(tokenResponse.Error);
                // Probably would be better to throw Exception and read from there
                return BadRequest(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var content = new StringContent(JsonSerializer.Serialize(createUserRequest), Encoding.UTF8, "application/json");
            var response = await apiClient.PostAsync("https://localhost:5001/api/users", content);


            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResult<CreateUserResponse>>(resultString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (!result.IsSuccessful)
            {
                _logger.LogError("{createUserResult}", result);
                // Redirect to Error Page or something like this.
                return BadRequest(result);
            }

            _logger.LogDebug("User Crated with id {id} and pending confirmation with code {code}", result.Data.Id, result.Data.ConfirmEmailCode);
            return Ok(result.Data);
        }
    }

    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class CreateUserResponse
    {
        public Guid Id { get; set; }
        public string ConfirmEmailCode { get; set; }

        public bool RequireConfirmedAccount { get; set; }
    }
}

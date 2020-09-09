using IdentityServer4.Models;
using System.Collections.Generic;

namespace ExpensesTracker.Identity.Data.Seed
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new [] {"role"}
                },
                new IdentityResource{
                    Name = "german",
                    UserClaims = new[] {"gclaim", "fclaim"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> {"api1.read", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                },
                 new ApiResource
                {
                    Name = "identity",
                    DisplayName = "Idenity Manager",
                    Description = "Allow the application to access Identity Manager on your behalf",
                    Scopes = new List<string> { "identity.admin", "api1.write"},
                    ApiSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("api1", "My API"),
                new ApiScope("identity", "Identity Server"),
                new ApiScope("identity.admin", "User Manager Administration"),
                new ApiScope("api1.read", "Read Access to API #1"),
                new ApiScope("api1.write", "Write Access to API #1"),
                //new ApiScope("ids.read", "Read Access to Identity Server"),
                //new ApiScope("ids.write", "Limited Write Access to Identity Server"),
                //new ApiScope("ids.admin", "Administion Access to Identity Server")
            };
        }
    }
}

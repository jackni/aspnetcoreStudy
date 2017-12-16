using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWeb
{
    public class Clients
    {

        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    ClientId = "openIdConnectClient",
                    ClientName = "Example Implicit Client Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },

                    RedirectUris = new List<string> {"https://localhost:44357/signin-oidc"},
                    PostLogoutRedirectUris = new List<string> {"https://localhost:44357"}
                },
                // OpenID Connect implicit flow
                new Client
                {
                    ClientId = "swaggerui",
                    ClientName = "Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                   
                    RedirectUris = { "http://localhost:3778/swagger/o2c.html" },
                    PostLogoutRedirectUris = { "http://localhost:3778/swagger/" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "api1"
                    }

                }
            };
        }
    }
}

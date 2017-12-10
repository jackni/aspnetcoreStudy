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
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    //ClientUri = "", this should be point to the web api, i will config it to my swagger endpoint
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {
                        new Secret("password".Sha256()) //client private key
                    },
                    AllowedScopes = new List<string> {"customAPI.read"}
                }
            };
        }
    }
}

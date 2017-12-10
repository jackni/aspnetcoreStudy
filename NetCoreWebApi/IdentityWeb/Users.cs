using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityWeb
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
            new TestUser {
                SubjectId = "##########-##########", //this should be a guid in real prj
                Username = "jackni",
#pragma warning disable S2068 // Credentials should not be hard-coded //for testing purpose
                Password = "password",
#pragma warning restore S2068 // Credentials should not be hard-coded
                Claims = new List<Claim> {
                    new Claim(JwtClaimTypes.Email, "jackni.ni@gmail.com"),
                    new Claim(JwtClaimTypes.Role, "admin")
                }
            }
        };
        }
    }
}

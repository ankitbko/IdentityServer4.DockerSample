using IdentityServer4.Core.Models;
using System.Collections.Generic;

namespace IdSvrHost.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oidc",
                    ClientName = "JavaScript OIDC Client",
                    ClientUri = "http://identityserver.io",

                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://192.168.99.100:7017/index.html",
                        "http://192.168.99.100:7017/silent_renew.html",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://192.168.99.100:7017/index.html",
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "http://192.168.99.100:7017"
                    },

                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.Roles.Name,
                        "api1"
                    }
                }
            };
        }
    }
}
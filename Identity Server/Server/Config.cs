using IdentityServer4.Models;

namespace Server
{
    //Pour plus de détails il faut voir la documentation de IentityServer
    //https://identityserver4.readthedocs.io/en/latest/
	public class Config
	{
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };

        //Les contextes d'utilisation qui seront spécifiée lors de la requête pour définir les autorisations
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("CoffeeAPI.read"), new ApiScope("CoffeeAPI.write"), };
       
        
        //Les ressources
        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("CoffeeAPI")
                {
                    Scopes = new List<string> { "CoffeeAPI.read", "CoffeeAPI.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };



        //Les clients pour les test
        public static IEnumerable<Client> Clients =>
            new[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },/*le secret du client 1 */
                    AllowedScopes = { "CoffeeAPI.read", "CoffeeAPI.write" },
                    AllowAccessTokensViaBrowser = true,
                },
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) }, /*le secret du client 2 */
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5444/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "CoffeeAPI.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false,
                    AllowAccessTokensViaBrowser = true
                },
            };
    }
}

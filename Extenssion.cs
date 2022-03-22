using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace openencoder
{
    public static class Extenssion
    {
        //private static IDictionary<string, object> GetClaims(string tenantId, string clientId)
        //{
        //    string aud = $"https://login.microsoftonline.com/{tenantId}/v2.0";

        //    string ConfidentialClientID = clientId;
        //    const uint JwtToAadLifetimeInSeconds = 60 * 10;
        //    DateTimeOffset validFrom = DateTimeOffset.UtcNow;
        //    DateTimeOffset validUntil = validFrom.AddSeconds(JwtToAadLifetimeInSeconds);

        //    return new Dictionary<string, object>(){
        //        { "aud", aud },
        //        { "exp", validUntil.ToUnixTimeSeconds() },
        //        { "iss", ConfidentialClientID },
        //        { "jti", Guid.NewGuid().ToString() },
        //        { "nbf", validFrom.ToUnixTimeSeconds() },
        //        { "sub", ConfidentialClientID }
        //    };
        //}

        //private static string Base64UrlEncode(byte[] arg)
        //    {
        //        char Base64PadCharacter = '=';
        //        char Base64Character62 = '+';
        //        char Base64Character63 = '/';
        //        char Base64UrlCharacter62 = '-';
        //        char Base64UrlCharacter63 = '_';

        //        string s = Convert.ToBase64String(arg);
        //        s = s.Split(Base64PadCharacter)[0];
        //        s = s.Replace(Base64Character62, Base64UrlCharacter62);
        //        s = s.Replace(Base64Character63, Base64UrlCharacter63);

        //        return s;
        //    }

        //    public static string GetSignedClientAssertion(this X509Certificate2 certificate, string tenantId, string clientId)
        //    {
        //        RSA? rsa = certificate.GetRSAPrivateKey();

        //        var header = new Dictionary<string, string>(){
        //            { "alg", "RS256"},
        //            { "typ", "JWT" },
        //            { "x5t", Base64UrlEncode(certificate.GetCertHash()) }
        //        };

        //        var claims = GetClaims(tenantId, clientId);

        //        var headerBytes = JsonSerializer.SerializeToUtf8Bytes(header);
        //        var claimsBytes = JsonSerializer.SerializeToUtf8Bytes(claims);
        //        string token = Base64UrlEncode(headerBytes) + "." + Base64UrlEncode(claimsBytes);

        //        string signature = Base64UrlEncode(rsa.SignData(Encoding.UTF8.GetBytes(token), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        //        string signedClientAssertion = string.Concat(token, ".", signature);
        //        return signedClientAssertion;
        //    }
        public static AuthenticationBuilder AddTokenAuthentication(this IServiceCollection Services)
        {
            return Services.AddAuthentication(options =>
            {
                options.DefaultScheme = TokenDefaults.AuthenticationScheme;
            }).AddScheme<AuthenticationSchemeOptions, TokenAuthenticationHandler>(TokenDefaults.AuthenticationScheme, o => { });
        }
    }

    public static class TokenDefaults
    {
        public const string AuthenticationScheme = "TokenAuthenticationScheme";
    }

    public class TokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private StringValues token;

        public IServiceProvider ServiceProvider { get; set; }

        public TokenAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IServiceProvider serviceProvider)
            : base(options, logger, encoder, clock)
        {
            ServiceProvider = serviceProvider;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Request.Headers.TryGetValue("X-MS-TOKEN-AAD-ACCESS-TOKEN", out token);

            if (string.IsNullOrEmpty(token.FirstOrDefault()))
            {
                return Task.FromResult(AuthenticateResult.Fail("Token is null"));
            }

            Claim[]? claims = new[] { new Claim("token", token.FirstOrDefault()) };
            ClaimsIdentity? identity = new(claims, nameof(TokenAuthenticationHandler));
            AuthenticationTicket? ticket = new(new ClaimsPrincipal(identity), Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

    }


    public class HeartBeat
    {
        public string? worker { get; set; }
        public string? db { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace MSRAPI
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //IUserDomain userDomain = new UserDomain();
            //var user = await userDomain.Login(context.UserName, context.Password);
            //if (user.StatusCode != Core.Utilities.Status.Success)
            var user = new Object();
            if (user != null)
            {
                context.SetError("error");
                return;
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim("UserId", "100"),
                    //new Claim("FirstName", user.FirstName),
                    //new Claim("LastName, user.LastName),
                    //new Claim("UserName, user.FullName),
                    //new Claim("Email, user.Email),
                    //new Claim("CookieTimeStamp, DateTimeOffset.Now.ToString("CookieTimeStampFormat, CultureInfo.InvariantCulture)),
                    //new Claim("UserFingerPrint, user.FingerPrint),
                    //new Claim("CompanyId, Convert.ToString(user.CompanyId)),
                    //new Claim("CompanyTypeId, Convert.ToString(user.CompanyTypeId)),
                    //new Claim("CompanyName, user.CompanyName ?? ""),
                    //new Claim("SelectedProfile, "0"),
                    //new Claim("ApplicationCulture, "en-US")
                };

                ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);

                var properties = CreateProperties("Email");
                var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}
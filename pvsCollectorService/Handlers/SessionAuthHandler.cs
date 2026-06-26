using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace pvsCollectorService.Handlers
{
    public class SessionAuthHandler : DelegatingHandler
    {
        private readonly ApplicationSettings _settings;
        private readonly CookieContainer _cookieContainer;
        private readonly string _authEndpoint;
        private readonly string _basicAuthHeaderValue;

        public SessionAuthHandler(CookieContainer cookieContainer, IOptions<ApplicationSettings> options)
        {
            _cookieContainer = cookieContainer;
            _settings = options.Value;

            // Construct the basic auth header value
            if (!string.IsNullOrEmpty(_settings.pvsUri))
            {
                _authEndpoint = $"{_settings.pvsUri.TrimEnd('/')}/auth?login";
            }
            else
            {
                throw new ArgumentNullException(nameof(_settings.pvsUri), "PVS URI cannot be null.");
            }

            if (!string.IsNullOrEmpty(_settings.pvsPassword))
            {
                if (!string.IsNullOrEmpty(_settings.pvsUsername))
                {
                    _basicAuthHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_settings.pvsUsername}:{_settings.pvsPassword}"));
                }
                else
                {
                    throw new ArgumentNullException(nameof(_settings.pvsUsername), "PVS Username cannot be null.");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_settings.pvsPassword), "PVS Password cannot be null.");
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var baseAddress = request.RequestUri ?? throw new InvalidOperationException("Request URI is required.");

            var cookies = _cookieContainer.GetCookies(baseAddress);
            var hasValidSession = cookies.Any(c => !c.Expired && c.Name == "session");

            // if we don't have a valid session cookie, authenticate first
            if(!hasValidSession)
            {
                await AuthenticateSessionAsync(cancellationToken);
            }

            // proceed with the original request (HttpClient will automatically attach the new cookie)
            var response = await base.SendAsync(request, cancellationToken)!;

            // If the response indicates that the session has expired, re-authenticate and retry the request
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Dispose();

                // Retry authentication once
                await AuthenticateSessionAsync(cancellationToken);
                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }

        private async Task AuthenticateSessionAsync(CancellationToken cancellationToken)
        {
            using var authRequest = new HttpRequestMessage(HttpMethod.Get, _authEndpoint);
            authRequest.Headers.Add("Authorization", $"Basic {_basicAuthHeaderValue}");

            using var authResponse = await base.SendAsync(authRequest, cancellationToken);

            if(!authResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Authentication failed with status code: {authResponse.StatusCode}");
            }
        }
    }    
}

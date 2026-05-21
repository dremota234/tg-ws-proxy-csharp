using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TgWsProxy.Routing.Interfaces;
using TgWsProxy.Routing.Models;

namespace TgWsProxy.Routing.Services
{
    public class TrafficRouter : ITrafficRouter
    {
        private readonly ILogger<TrafficRouter> _logger;
        private readonly RoutingOptions _options;

        public TrafficRouter(ILogger<TrafficRouter> logger, IOptions<RoutingOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public async Task<RouteDecision> GetRouteAsync(string targetHost, int targetPort, CancellationToken ct = default)
        {
            var host = targetHost.ToLowerInvariant();

            if (IsTelegramTraffic(host, targetPort))
            {
                _logger.LogDebug("Telegram traffic detected: {Host}:{Port}", host, targetPort);
                return new RouteDecision
                {
                    Type = RouteType.TelegramWS,
                    TargetHost = targetHost,
                    TargetPort = targetPort
                };
            }

            if (ShouldUseZapret(host))
            {
                _logger.LogDebug("Zapret route for: {Host}", host);
                return new RouteDecision
                {
                    Type = RouteType.Zapret,
                    TargetHost = targetHost,
                    TargetPort = targetPort,
                    ZapretPort = _options.ZapretPort
                };
            }

            return new RouteDecision
            {
                Type = RouteType.Direct,
                TargetHost = targetHost,
                TargetPort = targetPort
            };
        }

        private bool IsTelegramTraffic(string host, int port)
        {
            return host.Contains("telegram.org") ||
                   host.Contains("web.telegram.org") ||
                   host.Contains("t.me") ||
                   host.EndsWith(".tg") ||
                   IsTelegramDC(host);
        }

        private bool ShouldUseZapret(string host)
        {
            foreach (var pattern in _options.ZapretDomains)
            {
                if (host.Contains(pattern))
                    return true;
            }
            return false;
        }

        private bool IsTelegramDC(string host)
        {
            return host.StartsWith("149.154.") || host.StartsWith("95.161.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TgWsProxy.Routing.Models;

namespace TgWsProxy.Routing.Interfaces
{
    public interface ITrafficRouter
    {
        /// <summary>
        /// Определяет, куда отправлять трафик
        /// </summary>
        Task<RouteDecision> GetRouteAsync(string targetHost, int targetPort, CancellationToken ct = default);
    }
}

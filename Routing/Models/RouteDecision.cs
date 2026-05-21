using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgWsProxy.Routing.Models
{
    public class RouteDecision
    {
        public RouteType Type { get; set; }
        public string? TargetHost { get; set; }
        public int TargetPort { get; set; }
        public int? ZapretPort { get; set; }
    }
}

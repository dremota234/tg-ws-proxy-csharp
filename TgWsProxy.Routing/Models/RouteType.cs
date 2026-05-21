using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgWsProxy.Routing.Models
{
    public enum RouteType
    {
        TelegramWS,   // Через WebSocket к Telegram (оригинальная логика)
        Zapret,       // Через zapret
        Direct,       // Прямое соединение
        Reject        // Блокировать
    }
}

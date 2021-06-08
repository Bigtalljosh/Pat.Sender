using System.Collections.Concurrent;
using System.Threading;

namespace Pat.Sender.Correlation
{
    public class CallContextCorrelationIdProvider : ICorrelationIdProvider
    {
        private const string Key = "CorrelationId";
        static ConcurrentDictionary<string, AsyncLocal<object>> state = new ConcurrentDictionary<string, AsyncLocal<object>>();
        public string CorrelationId => state.TryGetValue(Key, out AsyncLocal<object> data) ? (string)data.Value : null;
    }
}
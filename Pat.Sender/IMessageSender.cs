using Microsoft.Azure.ServiceBus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pat.Sender
{
    public interface IMessageSender
    {
        Task SendMessages(IEnumerable<Message> messages);
    }
}
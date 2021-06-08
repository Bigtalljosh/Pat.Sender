using Microsoft.Azure.ServiceBus;
using System;

namespace Pat.Sender.MessageGeneration
{
    public interface IMessageGenerator
    {
        [Obsolete("Use GenerateMessage Instead")]
        Message GenerateBrokeredMessage(object message);
        Message GenerateMessage(object message);
    }
}

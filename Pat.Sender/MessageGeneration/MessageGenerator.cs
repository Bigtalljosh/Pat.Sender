﻿using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace Pat.Sender.MessageGeneration
{
    public class MessageGenerator : IMessageGenerator
    {
        public Message GenerateBrokeredMessage(object payload)
        {
            return new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
        }

        public Message GenerateMessage(object payload)
        {
            return new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
        }
    }
}

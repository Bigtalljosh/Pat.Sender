using Microsoft.Azure.ServiceBus;
using NSubstitute;
using Pat.Sender.Legacy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pat.Sender.UnitTests
{
    public class LegacyMessagePublisherTests
    {
        [Fact]
        public async Task WhenPublishMessage_MessageTypeIsAsSpecifiedBySenderAsync()
        {
            var messageSender = Substitute.For<IMessageSender>();
            var messagePublisher = new LegacyMessagePublisher(messageSender);

            await messagePublisher.PublishLegacyMessage(new Event1(), "WotISaid", "NotThis");

            await messageSender.Received(1)
                .SendMessages(Arg.Is<IEnumerable<Message>>(p =>
                p.Any(m => ((string)m.UserProperties["MessageType"]).Equals("WotISaid"))));
        }

        [Fact]
        public async Task WhenPublishMessage_ContentTypeIsAsSpecifiedBySenderAsync()
        {
            var messageSender = Substitute.For<IMessageSender>();
            var messagePublisher = new LegacyMessagePublisher(messageSender);

            await messagePublisher.PublishLegacyMessage(new Event1(), "NotThis", "IAskedForThis");

            await messageSender.Received(1)
                .SendMessages(Arg.Is<IEnumerable<Message>>(p =>
                p.Any(m => m.ContentType.Equals("IAskedForThis"))));
        }
    }
}

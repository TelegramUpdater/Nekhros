using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes;

namespace Nekhros.MyCustomAttributes
{
    internal sealed class MessageTypeAttribute : FilterAttributeBuilder
    {
        public MessageTypeAttribute(MessageType messageType)
            : base(builder => builder.AddFilterForUpdate<Message>(
                new(message => message.Type == messageType)))
        {
        }
    }
}

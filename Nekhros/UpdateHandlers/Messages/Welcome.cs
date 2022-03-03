using Microsoft.Extensions.Localization;
using Nekhros.MyCustomAttributes;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.ScopedHandlers.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [MessageType(MessageType.ChatMembersAdded), Group]
    internal sealed class Welcome : ScopedMessageHandler
    {
        private readonly IStringLocalizer<Welcome> _localizer;

        public Welcome(IStringLocalizer<Welcome> localizer)
        {
            _localizer = localizer;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            var newUsers = cntr.Update.NewChatMembers;

            foreach (var user in newUsers!)
            {
                await cntr.Response(_localizer.GetString("WelcomeMessage", user.FirstName));
            }
        }
    }
}

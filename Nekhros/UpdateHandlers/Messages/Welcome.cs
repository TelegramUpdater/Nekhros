using Microsoft.Extensions.Localization;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    /// <summary>
    /// Here i send welcome message to newly joined user to a group.
    /// </summary>
    [MessageType(MessageType.ChatMembersAdded), Group]
    internal sealed class Welcome : MessageHandler
    {
        private readonly IStringLocalizer<Welcome> _localizer;

        public Welcome(IStringLocalizer<Welcome> localizer)
        {
            _localizer = localizer;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            var newUsers = cntr.Update.NewChatMembers;

            await cntr.Delete().TryExecute<ApiRequestException>();

            foreach (var user in newUsers!)
            {
                await cntr.Response(
                    _localizer.GetString("WelcomeMessage", user.FirstName));
            }
        }
    }
}

using Microsoft.Extensions.Localization;
using Telegram.Bot;
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
        private readonly TephrosClient _tephrosClient;

        public Welcome(IStringLocalizer<Welcome> localizer, TephrosClient tephrosClient)
        {
            _localizer = localizer;
            _tephrosClient = tephrosClient;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            var newUsers = cntr.Update.NewChatMembers;

            await cntr.Delete().TryExecute<ApiRequestException>();

            foreach (var user in newUsers!)
            {
                if (user.Id == BotClient.BotId)
                    continue;

                await cntr.ResponseAsync(
                    _localizer.GetString("WelcomeMessage", user.FirstName));

                if (_tephrosClient.ShellTephrosAnswer)
                {
                    await _tephrosClient.SendChatActionAsync(Chat.Id, ChatAction.Typing);
                    await Task.Delay(2000);

                    var message = await _tephrosClient.SendTextMessageAsync(
                        Chat.Id, $"Yeah {user.FirstName}, you better stay cool.");

                    if (_tephrosClient.ShellTephrosAnswer)
                    {
                        await BotClient.SendChatActionAsync(Chat.Id, ChatAction.Typing);
                        await Task.Delay(2000);

                        await BotClient.SendTextMessageAsync(
                            Chat.Id, $"Don't be rude Tephros!",
                            replyToMessageId: message.MessageId,
                            allowSendingWithoutReply: true);
                    }
                }
            }
        }
    }
}

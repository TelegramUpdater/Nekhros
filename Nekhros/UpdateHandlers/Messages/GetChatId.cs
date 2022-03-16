using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [
        Command("chatid", "Get chat id.", 1,
            botUsername: "NekhrosBot",
            botCommandScopeType: BotCommandScopeType.AllGroupChats),
        Group
    ]
    internal sealed class GetChatId : MessageHandler
    {
        private readonly TephrosClient _tephrosClient;

        public GetChatId(TephrosClient tephrosClient)
        {
            _tephrosClient = tephrosClient;
        }

        protected override async Task HandleAsync(IContainer<Message> _)
        {
            if (_tephrosClient.ShellTephrosAnswer)
            {
                var message = await _tephrosClient.SendTextMessageAsync(
                    Chat.Id, $"That's my turn: {Chat.Id.ToString().ToHtmlCode()}");

                await BotClient.SendChatActionAsync(Chat.Id, ChatAction.Typing);
                await Task.Delay(2000);

                await BotClient.SendTextMessageAsync(
                    Chat.Id, "...",
                    replyToMessageId: message.MessageId,
                    allowSendingWithoutReply: true);
            }
            else
            {
                var message = await ResponseAsync(
                    Chat.Id.ToString().ToHtmlCode(),
                    parseMode: ParseMode.Html);

                if (_tephrosClient.ShellTephrosAnswer)
                {
                    await _tephrosClient.SendChatActionAsync(Chat.Id, ChatAction.Typing);
                    await Task.Delay(2000);

                    await _tephrosClient.SendTextMessageAsync(
                        Chat.Id, "Bravo, what a smart Nekhros )",
                        replyToMessageId: message.MessageId,
                        allowSendingWithoutReply: true);
                }
            }
        }
    }
}

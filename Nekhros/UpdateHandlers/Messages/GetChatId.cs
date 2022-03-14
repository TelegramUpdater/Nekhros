using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [
        Command("chatid", "Get chat id.", 1,
            botCommandScopeType: BotCommandScopeType.AllGroupChats),
        Group
    ]
    internal sealed class GetChatId : MessageHandler
    {
        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.ResponseAsync(cntr.Update.Chat.Id.ToString());
        }
    }
}

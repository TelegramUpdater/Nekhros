﻿using Microsoft.Extensions.Localization;
using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.ScopedHandlers.ReadyToUse;

namespace Nekhros.UpdateHandlers.Messages
{
    [Command("start"), Private]
    internal sealed class Start : ScopedMessageHandler
    {
        private readonly IStringLocalizer<Start> _localizer;

        public Start(IStringLocalizer<Start> localizer)
        {
            _localizer = localizer;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            await cntr.Response(_localizer.GetString("StartMessage", cntr.Sender()!.FirstName));
        }
    }
}

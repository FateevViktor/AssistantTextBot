using Telegram.Bot;
using Telegram.Bot.Types;
using AssistantTextBot.Configuration;

namespace AssistantTextBot.Controllers
{
    public class VoiceMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public VoiceMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            await _telegramClient.SendMessage(message.Chat.Id, $"С голосовыми сообщениями я пока не работаю", cancellationToken: ct);
        }
    }
}

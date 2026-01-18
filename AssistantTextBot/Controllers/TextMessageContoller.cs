using AssistantTextBot.Configuration;
using AssistantTextBot.Services;
using AssistantTextBot.Utilities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace AssistantTextBot.Controllers
{
    public class TextMessageController
    {
        int sum; //Сумма символов
        double res; //Результат сложения
        string str; //Текстовая переменная

        private SumNumbers sumNumbers=new SumNumbers(' ');
        private SumSymbol sumSymbol = new SumSymbol();

        private readonly AppSettings _appSettings; //Настройки бота

        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
            str = "";
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            if (message.Text == null)
            {
                return;
            }
            else
            {
                str=WordUtilities.start(message.Text);                
            }
            switch (str)
            {
                case "/start":

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Количество символов" , $"SumSymbol"),
                        InlineKeyboardButton.WithCallbackData($" Сумма чисел" , $"SumNumbers")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendMessage(message.Chat.Id, $"<b>  Наш бот работает с текстом.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Можно подсчитать количество символов или сумму чисел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;

                default:

                    string s = _memoryStorage.GetSession(message.Chat.Id).SelectedAction;

                    switch (s)
                    {
                        case "SumSymbol":
                            {
                                sumSymbol.Str = message.Text.Substring(1);
                                sum = sumSymbol.Sum();
                                await _telegramClient.SendMessage(message.Chat.Id, "В вашем сообщении " + Convert.ToString(sum) + " символ" + WordUtilities.Ending(sum), cancellationToken: ct);
                                break;
                            }
                        case "SumNumbers":
                            {
                                sumNumbers.Str = message.Text.Substring(1);
                                if (sumNumbers.Sum() == true) //Если удолось преобразовать
                                {
                                    res = sumNumbers.Result;
                                    await _telegramClient.SendMessage(message.Chat.Id, "Сумма ваших чисел равна " + Convert.ToString(res), cancellationToken: ct);
                                }
                                else //не удалось преобразовать в double
                                {
                                    await _telegramClient.SendMessage(message.Chat.Id, sumNumbers.Log, cancellationToken: ct);
                                }
                                break;
                            }
                        default:
                            {

                                break;
                            }
                    }
                    break;
            }
        }
    }
}

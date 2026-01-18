using static System.Net.Mime.MediaTypeNames;

namespace AssistantTextBot.Utilities
{
    public static class WordUtilities
    {
        /// <summary>
        /// Метод добавляет оканчание
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string Ending(int x)
        {
            string result;
            switch(x)
            {
                case 0: 
                    {
                        result = "ов";
                        break;
                    }
                case 1:
                    {
                        result = "";
                        break;
                    }
                case 2:
                    {
                        result = "а";
                        break;
                    }
                case 3:
                    {
                        result = "а";
                        break;
                    }
                case 4:
                    {
                        result = "а";
                        break;
                    }
                default:
                    {
                        result = "ов";
                        break;
                    }
            }
            return result;
        }
        /// <summary>
        /// Отрезаем Username, который телеграм добавляет к команде /start в чатах
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string start(string s)
        {
            string result;
            string[] words = s.Split(new char[] { '@' });
            if (words[0] == "/start")
            {
                result = words[0];
            }
            else
            {
                result= s;
            }
            return result;
        }
    }
}

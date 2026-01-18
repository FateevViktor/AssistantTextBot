
using System.Diagnostics.Eventing.Reader;

namespace AssistantTextBot.Services
{
    public class SumNumbers
    {
        public string Str { get; set; }
        public string Log { get; set; }
        char Separator; //разделитель
        public double Result { get; set; } //сумма
        double x;
        /// <summary>
        /// Необходимо задать разделитель цифр
        /// </summary>
        /// <param name="separator"></param>
        public SumNumbers(char separator)
        {
            Separator = separator;
            Str = "";
            Result = 0;
            Log = "";
        }
        public bool Sum()
        {
            bool result=false;
            Result = 0;
            string[] words = Str.Split(Separator);
            foreach (string element in words)
            {
                if (element.Length > 0)
                {
                    result=double.TryParse(element, out x);
                    if(result == false)
                    {
                        Log = "Значение (" + element + ") не является числом";
                        break;
                    }
                    else
                    {
                        Result = Result + x;
                    }
                }
                else
                {
                    result=false;
                    Log = "Нет числа между разделителем";
                    break;
                }
            }
            return result;
        }
    }
}



namespace AssistantTextBot.Model
{
    public class Session
    {
        /// <summary>
        /// Хранит выбранное действие
        /// SumSymbol - если хотим посчитать количество символов
        /// SumNumbers - Если хотим суммировать введенные числа
        /// </summary>
        public string SelectedAction { get; set; }
    }
}

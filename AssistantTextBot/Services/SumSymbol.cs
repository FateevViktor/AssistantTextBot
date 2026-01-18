
namespace AssistantTextBot.Services
{
    public class SumSymbol
    {
        public string Str { get; set; }
        public SumSymbol()
        {
            Str = "";
        }
        public int Sum()
        {
            return Str.Length;
        }
    }
}

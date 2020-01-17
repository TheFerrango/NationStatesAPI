namespace NationStatesAPI.Models.Dispatch
{
    public class Factbook
    {
        public const int DispatchType = 1;

        public enum FactbookType
        {
            History = 101,
            Geography = 102,
            Culture = 103,
            Politics = 104,
            Legislation = 105,
            Religion = 106,
            Military = 107,
            Economy = 108,
            International = 109,
            Trivia = 110,
            Miscellaneous = 111
        }
    }
}

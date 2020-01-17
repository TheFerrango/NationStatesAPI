namespace NationStatesAPI.Models.Dispatch
{
    public class Account
    {
        public const int DispatchType = 5;

        public enum AccountType
        {
            Military = 505,
            Trade = 515,
            Sport = 525,
            Drama = 535,
            Diplomacy = 545,
            Science = 555,
            Culture = 565,
            Other = 595
        }
    }
}

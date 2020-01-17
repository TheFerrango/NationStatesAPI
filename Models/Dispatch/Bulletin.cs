namespace NationStatesAPI.Models.Dispatch
{
    public class Bulletin
    {
        public const int DispatchType = 2;

        public enum BulletinType{
            Policy=305,
            News=315,
            Opinion=325,
            Campaign=385
        }
    }
}

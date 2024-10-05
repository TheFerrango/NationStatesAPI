using System.Threading.Tasks;
using NationStatesAPI.Models;

namespace NationStatesAPI.Interfaces
{
    public interface INationStandard
    {
        Task<Nation> GetNationAsync(string nationName);
    }

    public interface INationPrivate
    {
        Task<Nation> GetPrivateAsync(string nationName);
    
    }

      public interface INationPublic
    {
        Task<Nation> GetPublicAsync(string nationName);
    
    }
 public interface INation: INationStandard, INationPrivate, INationPublic{}   

 
}

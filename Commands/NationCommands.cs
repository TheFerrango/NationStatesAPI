
using System;
using System.Linq;
using System.Threading.Tasks;
using NationStatesAPI.Models;
using NationStatesAPI.Support;

namespace NationStatesAPI.Commands
{
    public class NationCommands
    {
        public NationCommands()
        {

        }

        public async Task<Nation> GetNationCensus(string nationName, params CensusEnum[] census)
        {            
            string strParams = "";
            if (census.Contains(CensusEnum.All))
            {
                strParams = $"?nation={nationName};q=census;scale=all";
            }
            else
            {
                strParams = $"?nation={nationName};q=census;scale={String.Join(",", census.Select(x => Convert.ToInt32(x)))}";
            }

            return await new NSHClient().GetPublicNSObjectAsync<Nation>(NSConsts.BASE_URL + strParams);
        }
        //https://www.nationstates.net/cgi-bin/api.cgi?nation=testlandia;q=census;scale=77+78;mode=history;from=1457856000

         public async Task<Nation> GetNationCensus(string nationName, DateTime from, DateTime to, params CensusEnum[] census)
        {            
            string strParams = "";
            if (census.Contains(CensusEnum.All))
            {
                strParams = $"?nation={nationName};q=census;scale=all";
            }
            else
            {
                strParams = $"?nation={nationName};q=census;scale={String.Join(",", census.Select(x => Convert.ToInt32(x)))}";
            }

            return await new NSHClient().GetPublicNSObjectAsync<Nation>(NSConsts.BASE_URL + strParams);
        }
    }
}
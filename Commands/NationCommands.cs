
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

         public async Task<Nation> GetHistoryNationCensus(string nationName, DateTime? from, DateTime? to, params CensusEnum[] census)
        {            
            string strParams = "";
            if (census.Contains(CensusEnum.All))
            {
                strParams = $"?nation={nationName};q=census;scale=all;mode=history";
            }
            else
            {
                strParams = $"?nation={nationName};q=census;scale={String.Join(",", census.Select(x => Convert.ToInt32(x)))};mode=history";
            }

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            if(from.HasValue)
            {
                strParams += $";from={Convert.ToInt64((from - epoch).Value.TotalSeconds).ToString()}";
            }
            if(to.HasValue)
            {
                strParams += $";to={Convert.ToInt64((to - epoch).Value.TotalSeconds).ToString()}";
            }

            return await new NSHClient().GetPublicNSObjectAsync<Nation>(NSConsts.BASE_URL + strParams);
        }
    }
}
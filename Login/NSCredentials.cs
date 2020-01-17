using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NationStatesAPI.Login
{
    public class NSCredentials
    {
        public bool IsValid {get; private set;}
        public string NationName {get;set;}
        public string Password { get; set; }
        public string XPassword { get; set; }
        public string PIN { get; set; }
        
        public NSCredentials(string nationName, string password)
        {
            this.NationName = nationName;
            this.Password = password;
        }
        
        public async Task<bool> Authenticate()
        {
            try{
                HttpClient hClient = new HttpClient();
                hClient.DefaultRequestHeaders.Clear();
                hClient.DefaultRequestHeaders.Add("x-password", this.Password);
                hClient.DefaultRequestHeaders.UserAgent.Clear();
                hClient.DefaultRequestHeaders.UserAgent.ParseAdd(NSConsts.USER_AGENT);
                var rqLgn = await hClient.GetAsync(NSConsts.BASE_URL + $"?nation={this.NationName}&q=unread");
                this.XPassword = rqLgn.Headers.GetValues("x-autologin").FirstOrDefault();
                this.PIN = rqLgn.Headers.GetValues("x-pin").FirstOrDefault();
                this.IsValid = true;
                return true;
            } 
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
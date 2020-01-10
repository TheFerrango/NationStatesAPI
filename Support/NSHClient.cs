using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NationStatesAPI.Login;

namespace NationStatesAPI.Support
{
    public class NSHClient : HttpClient
    {
        private NSCredentials NSCreds;

        public NSHClient()
        {            
        }

        public NSHClient(NSCredentials nscred)
        {
            this.NSCreds = nscred;
        }

        public async Task<T> GetNSObjectAsync<T>(string urlWithParameters) where T: class
        {
            if(this.NSCreds == null)
            {
                throw new InvalidOperationException("An NSCredentials object needs to be provided in order to use the function. In credential-free mode, only calls to the GetPublicNSObjectAsync function are allowed.");
            }

            this.DefaultRequestHeaders.Clear();
            this.DefaultRequestHeaders.Add("x-autologin", this.NSCreds.XPassword);
            this.DefaultRequestHeaders.Add("x-pin", this.NSCreds.PIN);

            this.DefaultRequestHeaders.UserAgent.Clear();
            this.DefaultRequestHeaders.UserAgent.ParseAdd("Software OverMistress");

            string xmlTxt = await this.GetStringAsync(urlWithParameters);
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(xmlTxt));
        }

        public async Task<T> GetPublicNSObjectAsync<T>(string urlWithParameters) where T: class
        {
            string xmlTxt = await this.GetStringAsync(urlWithParameters);
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(xmlTxt));
        }
    }
}

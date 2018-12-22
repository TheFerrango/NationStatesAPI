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

        public NSHClient(NSCredentials nscred)
        {
            this.NSCreds = nscred;
        }

        public async Task<T> GetNSObjectAsync<T>(string urlWithParameters) where T: class
        {
            this.DefaultRequestHeaders.Clear();
            this.DefaultRequestHeaders.Add("x-autologin", this.NSCreds.XPassword);
            this.DefaultRequestHeaders.Add("x-pin", this.NSCreds.PIN);

            this.DefaultRequestHeaders.UserAgent.Clear();
            this.DefaultRequestHeaders.UserAgent.ParseAdd("Software OverMistress");

            string xmlTxt = await this.GetStringAsync(urlWithParameters);
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(xmlTxt));
        }
    }
}

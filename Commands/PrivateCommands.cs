using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NationStatesAPI.Login;
using NationStatesAPI.Models;
using NationStatesAPI.Support;

namespace NationStatesAPI.Commands
{
    public class PrivateCommands
    {
        NSCredentials NCred { get; set; }
        public PrivateCommands(NSCredentials nscred)
        {
            if (!nscred.IsValid)
                throw new InvalidOperationException("The credentials object was not validated");

            this.NCred = nscred;
        }

        public async Task<NationalIssues> GetIssues()
        {
            NSHClient nshClient = new NSHClient(this.NCred) ;
            return await nshClient.GetNSObjectAsync<NationalIssues>(NSConsts.BASE_URL + $"?nation={this.NCred.NationName}&q=issues");
            // HttpClient hClient = new HttpClient();
            // hClient.DefaultRequestHeaders.Clear();
            // hClient.DefaultRequestHeaders.Add("x-autologin", this.NCred.XPassword);
            // hClient.DefaultRequestHeaders.Add("x-pin", this.NCred.PIN);
            // hClient.DefaultRequestHeaders.UserAgent.Clear();
            // hClient.DefaultRequestHeaders.UserAgent.ParseAdd("Software OverMistress");
            // string xmlTxt = await hClient.GetStringAsync(NSConsts.BASE_URL + $"?nation={this.NCred.NationName}&q=issues");

            // return (NationalIssues)new XmlSerializer(typeof(NationalIssues)).Deserialize(new StringReader(xmlTxt));
        }

        public async Task<IssuePlayedResponse> PlayIssue(int idIssue, int idOption)
        {
            HttpClient hClient = new HttpClient();
            hClient.DefaultRequestHeaders.Clear();
            hClient.DefaultRequestHeaders.Add("x-autologin", this.NCred.XPassword);
            hClient.DefaultRequestHeaders.Add("x-pin", this.NCred.PIN);

            hClient.DefaultRequestHeaders.UserAgent.Clear();
            hClient.DefaultRequestHeaders.UserAgent.ParseAdd("Software OverMistress");
            //             StringContent sc = new StringContent($"?nation={this.NCred.NationName}&c=issue&issue={idIssue}&option={idOption}");
            //             sc.Headers.Clear();
            // sc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string xmlTxt = await hClient.GetStringAsync(NSConsts.BASE_URL + $"?nation={this.NCred.NationName}&c=issue&issue={idIssue}&option={idOption}");//hClient.PostAsync(NSConsts.BASE_URL, sc);

            return (IssuePlayedResponse)new XmlSerializer(typeof(IssuePlayedResponse)).Deserialize(new StringReader(xmlTxt));
        }
    }

}
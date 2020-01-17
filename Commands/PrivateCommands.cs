using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
            NSHClient nshClient = new NSHClient(this.NCred);
            return await nshClient.GetNSObjectAsync<NationalIssues>(NSConsts.BASE_URL + $"?nation={this.NCred.NationName}&q=issues");
        }

        public async Task<IssuePlayedResponse> PlayIssue(int idIssue, int idOption)
        {
            HttpClient hClient = new HttpClient();
            hClient.DefaultRequestHeaders.Clear();
            hClient.DefaultRequestHeaders.Add("x-autologin", this.NCred.XPassword);
            hClient.DefaultRequestHeaders.Add("x-pin", this.NCred.PIN);

            hClient.DefaultRequestHeaders.UserAgent.Clear();
            hClient.DefaultRequestHeaders.UserAgent.ParseAdd(NSConsts.USER_AGENT);

            string xmlTxt = await hClient.GetStringAsync(NSConsts.BASE_URL + $"?nation={this.NCred.NationName}&c=issue&issue={idIssue}&option={idOption}");//hClient.PostAsync(NSConsts.BASE_URL, sc);

            return (IssuePlayedResponse)new XmlSerializer(typeof(IssuePlayedResponse)).Deserialize(new StringReader(xmlTxt));
        }

        public Task<DispatchResponse> CreateDispatch(int dispatchType, int dispatchSubtype, string title, string body)
        {
           return this.AddOrEditDispatch(null, dispatchType, dispatchSubtype, title, body);
           
        }
        
        public Task<DispatchResponse> EditDispatch(int dispatchId, int dispatchType, int dispatchSubtype, string title, string body)
        {
           return this.AddOrEditDispatch(dispatchId, dispatchType, dispatchSubtype, title, body);
        }


        private async Task<DispatchResponse> AddOrEditDispatch(int? dispatchId, int dispatchType, int dispatchSubtype, string title, string body)
        {
            HttpClient hClient = new HttpClient();
            hClient.DefaultRequestHeaders.Clear();
            hClient.DefaultRequestHeaders.Add("x-autologin", this.NCred.XPassword);
            hClient.DefaultRequestHeaders.Add("x-pin", this.NCred.PIN);

            hClient.DefaultRequestHeaders.UserAgent.Clear();
            hClient.DefaultRequestHeaders.UserAgent.ParseAdd(NSConsts.USER_AGENT);

            List<KeyValuePair<string, string>> toPost = new List<KeyValuePair<string, string>>();

            toPost.Add(new KeyValuePair<string, string>("nation", this.NCred.NationName));
            toPost.Add(new KeyValuePair<string, string>("c", "dispatch"));

            if(dispatchId.HasValue)
            {
                toPost.Add(new KeyValuePair<string, string>("dispatch", "edit"));
                toPost.Add(new KeyValuePair<string, string>("dispatchid", dispatchId.ToString()));
            } 
            else
            {
                toPost.Add(new KeyValuePair<string, string>("dispatch", "add"));
            }
            
            toPost.Add(new KeyValuePair<string, string>("title", title));
            toPost.Add(new KeyValuePair<string, string>("text", body));
            toPost.Add(new KeyValuePair<string, string>("category", dispatchType.ToString()));
            toPost.Add(new KeyValuePair<string, string>("subcategory", dispatchSubtype.ToString()));

            var modeKVP = new KeyValuePair<string, string>("mode", "prepare");
            toPost.Add(modeKVP);

            var xmlTxt = await hClient.PostAsync(NSConsts.BASE_URL, new FormUrlEncodedContent(toPost));
            var readTxt = await xmlTxt.Content.ReadAsStringAsync();
            var successResponse = (DispatchResponse)new XmlSerializer(typeof(DispatchResponse)).Deserialize(new StringReader(readTxt));
            
            toPost.Remove(modeKVP);
            modeKVP = new KeyValuePair<string, string>("mode", "execute");
            toPost.Add(modeKVP);
            toPost.Add(new KeyValuePair<string, string>("token", successResponse.SUCCESS));
            xmlTxt = await hClient.PostAsync(NSConsts.BASE_URL, new FormUrlEncodedContent(toPost));
            readTxt = await xmlTxt.Content.ReadAsStringAsync();

            return (DispatchResponse)new XmlSerializer(typeof(DispatchResponse)).Deserialize(new StringReader(readTxt));;
        }

        public async Task<DispatchResponse> DeleteDispatch(int dispatchId)
        {
            HttpClient hClient = new HttpClient();
            hClient.DefaultRequestHeaders.Clear();
            hClient.DefaultRequestHeaders.Add("x-autologin", this.NCred.XPassword);
            hClient.DefaultRequestHeaders.Add("x-pin", this.NCred.PIN);

            hClient.DefaultRequestHeaders.UserAgent.Clear();
            hClient.DefaultRequestHeaders.UserAgent.ParseAdd(NSConsts.USER_AGENT);

            List<KeyValuePair<string, string>> toPost = new List<KeyValuePair<string, string>>();

            toPost.Add(new KeyValuePair<string, string>("nation", this.NCred.NationName));
            toPost.Add(new KeyValuePair<string, string>("c", "dispatch"));
            toPost.Add(new KeyValuePair<string, string>("dispatch", "remove"));
            toPost.Add(new KeyValuePair<string, string>("dispatchid", dispatchId.ToString()));

            var modeKVP = new KeyValuePair<string, string>("mode", "prepare");
            toPost.Add(modeKVP);

            var xmlTxt = await hClient.PostAsync(NSConsts.BASE_URL, new FormUrlEncodedContent(toPost));
            var readTxt = await xmlTxt.Content.ReadAsStringAsync();
            var successResponse = (DispatchResponse)new XmlSerializer(typeof(DispatchResponse)).Deserialize(new StringReader(readTxt));
            
            toPost.Remove(modeKVP);
            modeKVP = new KeyValuePair<string, string>("mode", "execute");
            toPost.Add(modeKVP);
            toPost.Add(new KeyValuePair<string, string>("token", successResponse.SUCCESS));
            xmlTxt = await hClient.PostAsync(NSConsts.BASE_URL, new FormUrlEncodedContent(toPost));
            readTxt = await xmlTxt.Content.ReadAsStringAsync();

            return (DispatchResponse)new XmlSerializer(typeof(DispatchResponse)).Deserialize(new StringReader(readTxt));;
        }
    }

}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace chatbot.Dialogs
{
    public static class InputHelper
    {
        public static async Task<UserInputInformation> ParseUserInput(string input)
        {
            UserInputInformation userInput = null;
            
            using (var client = new HttpClient())
            {
                string subscriptionKey = ConfigurationManager.AppSettings["LuisSubscriptionKey"].ToString();
                string LuisAppId = ConfigurationManager.AppSettings["LuisAppId"].ToString();
                string appGuid = ConfigurationManager.AppSettings["appGuid"].ToString();
                string query = Uri.EscapeDataString(input);

                string uri = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/{appGuid}?subscription-key={subscriptionKey}&ID={LuisAppId}&q={query}";

                try
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();

                    var data = await response.Content.ReadAsStringAsync();
                    userInput = JsonConvert.DeserializeObject<UserInputInformation>(data);
                }
                catch (Exception ex)
                {

                }
                return userInput;
            }
        }
    }
}
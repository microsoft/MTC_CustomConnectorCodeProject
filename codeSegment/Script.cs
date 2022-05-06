using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

public class Script : ScriptBase
{

    public Script()
    {
        
    }
    public override StringContent CreateJsonContent(string serializedJson)
    {
        return new StringContent(serializedJson);
    }

    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        try
        {
            if(this.Context.OperationId == "GetSessions")
            {
                return await this.HandleGetSessions();
            }            
        }
        catch (Exception ex)
        {            
            Console.WriteLine(ex.Message);
        }
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = CreateJsonContent($"Unknown operation ID '{this.Context.OperationId}'");
            return response;
    }

    private async Task<HttpResponseMessage> HandleGetSessions()
    {
        HttpResponseMessage response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken);

        if(response.IsSuccessStatusCode)
        {
            //get the response as a string
            var responseString = await response.Content.ReadAsStringAsync();

            //convert the string to a json object
            var rawResultAsJson = JObject.Parse(responseString);

            //create the empty shells
            var responseItems = @"{'collection':{'items':[]}}";

            //create the JObject Handles
            JObject itemsTemplateParsed = JObject.Parse(responseItems);
            JArray itemsTemplateArray = (JArray)itemsTemplateParsed["collection"]["items"];

            try
            {
                if(rawResultAsJson != null)
                {
                    //get the array of items from the response
                    var itemsFromResponse = (JArray)rawResultAsJson["collection"]["items"];
                    
                    
                    //loop through the items in the response
                    foreach(var item in itemsFromResponse)
                    {
                        //zero out the variables
                        string currTitle = string.Empty;
                        string currDate = string.Empty;
                        string currSpeaker = string.Empty;

                        //get the collection of items in the data array
                        var dataArray = (JArray)item["data"];

                        //loop through each item to find the title, timeslot and speaker
                        foreach(var dItem in dataArray)
                        {
                            if(dItem["name"].ToString() == "Title")
                            {
                                currTitle = dItem["value"].ToString();

                            }
                            else if(dItem["name"].ToString() == "Timeslot")
                            {
                                currDate = dItem["value"].ToString();
                            }
                            else if(dItem["name"].ToString() == "Speaker")
                            {
                                currSpeaker = dItem["value"].ToString();
                            }
                        }
                        JObject thisItem = new JObject(
                            new JProperty("href", item["href"]),
                            new JProperty("title", currTitle),
                            new JProperty("timeslot", currDate),
                            new JProperty("speaker", currSpeaker)
                        );
                        itemsTemplateArray.Add(thisItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            response.Content = CreateJsonContent(itemsTemplateParsed.ToString());

        }

        return response;
    }
}


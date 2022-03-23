using Newtonsoft.Json.Linq;
using System.Net;

public class Script : ScriptBase
{
    public override StringContent CreateJsonContent(string serializedJson)
    {
        return new StringContent(serializedJson);
    }

    public Script()
    {
        
    }

    public override async Task<string> ExecuteAsync()
    {
        try
        {
            //TODO: uncomment
            // if(this.Context.OperationId == "GetSessions")
            // {
                return await this.HandleGetSessions().ConfigureAwait(false);
            // }

            
        }
        catch (Exception ex)
        {            
            Console.WriteLine(ex.Message);
        }
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = CreateJsonContent($"Unknown operation ID '{this.Context.OperationId}'");
            return "Hello"; //;
    }

    private async Task<string> HandleGetSessions()
    {
        //HttpResponseMessage response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken);

        // if(response.IsSuccessStatusCode)
        // {
            //get the response as a string
            var responseString = myJsonResponse.response; // await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);

            //convert the string to a json object
            var rawResultAsJson = JObject.Parse(responseString);

            //create the empty shells
            var responseItems = @"{'items':[]}";
            var responseItem = @"{'href':'','title':'','timeslot':'','speaker':''}";

            //create the JObject Handles
            JObject itemsTemplateParsed = JObject.Parse(responseItems);
            JArray itemsTemplateArray = (JArray)itemsTemplateParsed["items"];

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

                        //load the item JObject with the empty shell
                        JObject itemTemplateParsed = JObject.Parse(responseItem);

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
            
        // }
        
        Console.WriteLine(itemsTemplateParsed.ToString());
        return "Hello"; // response;
    }
}
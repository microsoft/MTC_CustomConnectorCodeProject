public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        if(this.Context.OperationId == "GetSessions")
        {
            return await this.HandleGetSessions().ConfigureAwait(false);
        }
    }

    private async Task<HttpResponseMessage> HandleGetSessions()
    {
        HttpResponseMessage response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken);

        if(response.IsSuccessStatusCode)
        {
            //get the response as a string
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);

            //convert the string to a json object
            var rawResultAsJson = JObject.Parse(responseString);

            
        }
        
        return response;
    }
}
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

public class Script : ScriptBase
{

    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        HttpResponseMessage response = null;

        try
        {
            response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken);
        }
        catch (Exception ex)
        {            
            response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = CreateJsonContent($"Error message: {ex.Message}");
        }
        
        return response;
    }
}
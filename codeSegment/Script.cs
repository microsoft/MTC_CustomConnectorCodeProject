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

            //confirm the operationid that is calling the connector
            if(this.Context.OperationId == "GetSessions")
            {
                //route the flow to the appropriate method
            }            
        }
        catch (Exception ex)
        {            
            Console.WriteLine(ex.Message);
        }
        
        //code for when operationid is not matched
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
        response.Content = CreateJsonContent($"Unknown operation ID '{this.Context.OperationId}'");
        return response;
    }
}
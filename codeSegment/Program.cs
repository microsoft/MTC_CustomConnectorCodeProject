// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

//variables:
//CustomConnectorUrl(Required) - url of the api used in the custom connector.
string CustomConnectorUrl = "https://conferenceapi.azurewebsites.net/sessions";// "[REPLACE WITH YOUR CUSTOM CONNECTOR URL]";

//OperationId(Required) - the operation id for the custom connector.
string OperationId = "GetSessions";//"[REPLACE WITH YOUR OPERATION ID]";

//Ocp-Apim-Subscription-Key(Optional) - the subscription key for the custom connector if using a service like API-M.
string OcpApimSubscriptionKey = "[REPLACE WITH YOUR OCP APIM SUBSCRIPTION KEY]";


try
{
    //create the HttpRequest that matches the request on the custom connector
    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, CustomConnectorUrl);
    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //ADD ANY ADDITIONAL HEADERS HERE

    //API-Management Subscription Key - uncomment if using API-M
    // requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", OcpApimSubscriptionKey);

    //create a new script object
    var myScript = new Script();

    //create a scriptcontext object and assign it to the Context property of the script class

    var myScriptContext = new ScriptContext(OperationId, requestMessage);
    myScript.Context = myScriptContext;

    //use the script object to execute the api call
    HttpResponseMessage response = myScript.ExecuteAsync().ConfigureAwait(true).GetAwaiter().GetResult();
    
    //write the results to the console.
    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

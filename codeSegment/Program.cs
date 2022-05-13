// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

//TODO: provide these settings.
string CustomConnectorUrl = "[REPLACE WITH CUSTOM CONNECTOR URL]"; //This is the url your custom connector uses.
string OcpApimSubscriptionKey = "[REPLACE WITH YOUR SUBSCRIPTION KEY]";  // if you use this, uncomment line 17 to include this value in the header.

try
{
    //create the HttpRequest that matches the request on the custom connector
    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, CustomConnectorUrl);
    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //ADD ANY ADDITIONAL HEADERS HERE
    //requestMessage.Headers.Add("[YOUR HEADER KEY]", "[YOUR HEADER VALUE]");

    //API-Management Subscription Key
    //requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", OcpApimSubscriptionKey);

    //create a new script object
    var myScript = new Script();

    //create a scriptcontext object and assign it to the Context property of the script class
    var myScriptContext = new ScriptContext("GetSessions", requestMessage);
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

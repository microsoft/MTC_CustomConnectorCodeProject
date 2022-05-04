// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

try
{
    //create the HttpRequest that matches the request on the custom connector
    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://conferenceapi.azurewebsites.net/sessions");
    requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "5003d038b3b84b499d8fca900b0b61e2");

    var myScript = new Script();
    var myScriptContext = new ScriptContext("GetSessions", requestMessage);
    myScript.Context = myScriptContext;    

    HttpResponseMessage response = myScript.ExecuteAsync().ConfigureAwait(true).GetAwaiter().GetResult();
    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

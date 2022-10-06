using System.Net.Http;
using System.Text;

public abstract class ScriptBase
{
    // Context object
    //added the setter, but only setting it outside of the Script impelementation.
    public IScriptContext Context { get; set; } 

    // CancellationToken for the execution
    public CancellationToken CancellationToken { get; }

    // Helper: Creates a StringContent object from the serialized JSON
    public static StringContent CreateJsonContent(string serializedJson)
    {
        //creating a dummy body so this will work in an abstract class
        return new StringContent(serializedJson, Encoding.UTF8, "application/json");
    }

    // Abstract method for your code
    public abstract Task<HttpResponseMessage> ExecuteAsync();
}

public interface IScriptContext
{
    // Correlation Id
    string CorrelationId { get; }

    // Connector Operation Id
    string OperationId { get; set; } //added the setter, but only setting it outside of the Script impelementation.

    // Incoming request
    HttpRequestMessage Request { get; set;} //added the setter, but only setting it outside of the Script impelementation.

    // Logger instance
    ILogger Logger { get; }

    // Used to send an HTTP request
    // Use this method to send requests instead of HttpClient.SendAsync
    Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken);
}

public interface ILogger
{
}
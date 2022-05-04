using System.Net.Http;
public abstract class ScriptBase
{
    // Context object
    public IScriptContext Context { get; set;} //added the setter, but only setting it outside of the Script impelementation.

    // CancellationToken for the execution
    public CancellationToken CancellationToken { get; }

    // Helper: Creates a StringContent object from the serialized JSON
    public abstract StringContent CreateJsonContent(string serializedJson);

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
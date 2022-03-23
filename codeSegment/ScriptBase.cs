public abstract class ScriptBase
{
    // Context object
    public IScriptContext Context { get; }

    // CancellationToken for the execution
    public CancellationToken CancellationToken { get; }

    // Helper: Creates a StringContent object from the serialized JSON
    public abstract StringContent CreateJsonContent(string serializedJson);

    // Abstract method for your code
    public abstract Task<string> ExecuteAsync();
}

public interface IScriptContext
{
    // Correlation Id
    string CorrelationId { get; }

    // Connector Operation Id
    string OperationId { get; }

    // Incoming request
    HttpRequestMessage Request { get; }

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
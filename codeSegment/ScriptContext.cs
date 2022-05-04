// See https://aka.ms/new-console-template for more information

public class ScriptContext : IScriptContext
{
    public string CorrelationId { get; }
    public string OperationId { get; set; }
    public HttpRequestMessage Request { get; set; }
    public ILogger Logger { get; }
    public CancellationToken CancellationToken { get; }

    public ScriptContext(string operationId, HttpRequestMessage request) 
        : this(operationId, request, null, CancellationToken.None)
    {
    }
    
    public ScriptContext(string operationId, HttpRequestMessage request, ILogger logger, CancellationToken cancellationToken)
    {
        OperationId = operationId;
        Request = request;
        Logger = logger;
        CancellationToken = cancellationToken;
    }

    public StringContent CreateJsonContent(string serializedJson)
    {
        return new StringContent(serializedJson);
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpClient client = new HttpClient();
        
        return await client.SendAsync(request, cancellationToken);
    }
}
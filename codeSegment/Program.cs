// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

try
{
    var response = new Script().ExecuteAsync().ConfigureAwait(true);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

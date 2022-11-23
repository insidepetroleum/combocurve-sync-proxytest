using ComboCurve.Sync.Proxy.Client.Clients;
using ComboCurve.Sync.Proxy.Client.Utilities;

var configuration = ConfigurationUtility.GetConfiguration();
var url = new Uri(configuration["serverUrl"]!);

try
{
    await ApiClient.CallApi(url, configuration);
    await HubClient.CallNotificationHubMethods(url, configuration);
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
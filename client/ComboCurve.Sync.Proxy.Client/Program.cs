using ComboCurve.Sync.Proxy.Client.Clients;
using ComboCurve.Sync.Proxy.Client.Utilities;

var configuration = ConfigurationUtility.GetConfiguration();
var url = new Uri(configuration["serverUrl"]!);

await ApiClient.CallApi(url, configuration);
await HubClient.CallNotificationHubMethods(url, configuration);

Console.ReadKey();
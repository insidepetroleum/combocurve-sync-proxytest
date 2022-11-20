using ComboCurve.Sync.Proxy.Client.Clients;

Console.Write("Server URL: ");

var rawUrl = Console.ReadLine();

rawUrl = "https://localhost:7116"; // TODO remove hardcoded

var url = new Uri(rawUrl);

await ApiClient.CallApi(url);

await HubClient.CallNotificationHubMethods(url);

Console.ReadKey();
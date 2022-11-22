# ComboCurve Sync proxy tester

This solution contains a simple [CLI utility](./client/ComboCurve.Sync.Proxy.Client/Program.cs) and its companion [backend](./backend/ComboCurve.Sync.Proxy.Backend/Program.cs). The utility supports a custom web proxy configuration (see the `appsettings.json` [file](./client/ComboCurve.Sync.Proxy.Client/appsettings.json)) and verifies the following actions:

 - simple HTTP request
 - connection to a SingnalR hub
 - receiving a message from the hub
# ComboCurve Sync proxy tester

This solution contains a simple [CLI utility](./client/ComboCurve.Sync.Proxy.Client/) and its companion [backend](./backend/ComboCurve.Sync.Proxy.Backend/). The utility supports a custom web proxy configuration (see the `appsettings.json` [file](./client/ComboCurve.Sync.Proxy.Client/appsettings.json)) and verifies the following actions:

 - sending a simple HTTP request
 - establishing a connection to a SingnalR hub
 - receiving a message from the hub
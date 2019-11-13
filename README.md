# bitso-client
REST API client for Bitso exchange
## Basic usage
1. Construct a Configuration object
2. Instantiate an api client
3. Call helper methods
```csharp
var config = new ClientConfiguration("base-url", "v3", "api-key", "api-secret");
var client = new HttpClient();
var requester = new HttpRequester(client);
var apiClient = new PublicApiClient(requester, config);
var response = await apiClient.GetOrderBookAsync("btc_mxn");
```

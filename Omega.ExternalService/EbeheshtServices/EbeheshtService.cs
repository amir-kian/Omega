using Microsoft.Extensions.Configuration;
using Omega.ExternalService.EbeheshtServices.Contracts;
using Omega.ExternalService.EbeheshtServices.Models;
using Omega.ExternalService.EbeheshtServices.Models.GetItem;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Omega.ExternalService.EbeheshtServices;

public class EbeheshtService : IEbeheshtService
{
	private readonly HttpClient _httpClient;
	private readonly IConfiguration _configuration;

	public EbeheshtService(HttpClient httpClient, IConfiguration configuration)
	{
		_httpClient = httpClient;
		_configuration = configuration;
	}

	public async Task<ServiceResponse> GetAllItemsAsync()
	{
		var baseUrl = _configuration.GetValue<string>("EbeheshtApi:BaseUrl");
		var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		request.Headers.Add("apikey", _configuration.GetValue<string>("EbeheshtApi:ApiKey"));

		var response = await _httpClient.SendAsync(request);

		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		var options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			IgnoreNullValues = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};
		var serviceResponse = JsonSerializer.Deserialize<ServiceResponse>(jsonResponse, options);

		return serviceResponse;
	}

	public async Task<GetItemResponse> GetItemAsync(int itemId)
	{
		var baseUrl = _configuration.GetValue<string>("EbeheshtApi:GetItemUrl");
		var request = new HttpRequestMessage(HttpMethod.Get, baseUrl +itemId);
		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		request.Headers.Add("apikey", _configuration.GetValue<string>("EbeheshtApi:ApiKey"));

		var response = await _httpClient.SendAsync(request);

		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		var options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			IgnoreNullValues = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};
		var serviceResponse = JsonSerializer.Deserialize<GetItemResponse>(jsonResponse, options);

		return serviceResponse;
	}
}







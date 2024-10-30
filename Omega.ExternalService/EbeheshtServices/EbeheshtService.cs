using Microsoft.Extensions.Configuration;
using Omega.ExternalService.EbeheshtServices.Contracts;
using Omega.ExternalService.EbeheshtServices.Models;
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
		request.Headers.Add("apikey", "C85FC5A0-B8FB-4D65-AEE1-B956E3E1D186");

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
}







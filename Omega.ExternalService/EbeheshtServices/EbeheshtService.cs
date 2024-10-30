using Omega.ExternalService.EbeheshtServices.Contracts;
using Omega.ExternalService.EbeheshtServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Omega.ExternalService.EbeheshtServices;

public class EbeheshtService: IEbeheshtService
{
	private readonly HttpClient _httpClient;

	public EbeheshtService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<ServiceResponse> GetAllItemsAsync()
	{
		var request = new HttpRequestMessage(HttpMethod.Get, "https://ebeheshtapi.tehran.ir/api/v1/Service/GetAllItems");
		request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		request.Headers.Add("apikey", "C85FC5A0-B8FB-4D65-AEE1-B956E3E1D186");

		var response = await _httpClient.SendAsync(request);

		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		var serviceResponse = JsonSerializer.Deserialize<ServiceResponse>(jsonResponse);

		return serviceResponse;
	}
}







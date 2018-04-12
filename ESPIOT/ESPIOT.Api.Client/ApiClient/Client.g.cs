using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.Client
{
	public abstract partial class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		public AbstractApiClient(string apiUri)
		{
			if (string.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}

			this.ApiUrl = apiUri;
			this.client = new HttpClient();

			this.client.BaseAddress = new Uri(apiUri);

			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual async Task<List<POCODevice>> DeviceSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices;
		}

		public virtual async Task<POCODevice> DeviceGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices.FirstOrDefault();
		}

		public virtual async Task<List<POCODevice>> DeviceGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices;
		}

		public virtual async Task DeviceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Devices/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DeviceUpdateAsync(int id, DeviceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Devices/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DeviceCreateAsync(DeviceModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DeviceBulkInsertAsync(List<DeviceModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCODeviceAction>> DeviceActionSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions;
		}

		public virtual async Task<POCODeviceAction> DeviceActionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions.FirstOrDefault();
		}

		public virtual async Task<List<POCODeviceAction>> DeviceActionGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions;
		}

		public virtual async Task DeviceActionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeviceActions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DeviceActionUpdateAsync(int id, DeviceActionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeviceActions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DeviceActionCreateAsync(DeviceActionModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DeviceActionBulkInsertAsync(List<DeviceActionModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>983dc8f498ead4285f57fbbcff51e379</Hash>
</Codenesium>*/
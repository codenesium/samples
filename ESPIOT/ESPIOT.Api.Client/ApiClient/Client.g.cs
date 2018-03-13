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
		public HttpClient _client;
		protected string ApiUrl { get; set; }
		public AbstractApiClient(string apiUri)
		{
			if (String.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}

			this.ApiUrl = apiUri;
			this._client = new HttpClient();

			this._client.BaseAddress = new Uri(apiUri);

			this._client.DefaultRequestHeaders.Accept.Clear();
			this._client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual async Task<List<POCODevice>>DeviceSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Devices?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices;
		}

		public virtual async Task<List<POCODevice>> DeviceGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Devices/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices;
		}

		public virtual async Task<POCODevice> DeviceGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Devices/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices.FirstOrDefault();
		}

		public virtual async Task<List<POCODevice>> DeviceGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Devices?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Devices;
		}

		public virtual async Task DeviceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Devices/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DeviceUpdateAsync(int id,DeviceModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Devices/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DeviceCreateAsync(DeviceModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Devices", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DeviceCreateManyAsync(List<DeviceModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Devices/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCODeviceAction>>DeviceActionSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DeviceActions?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions;
		}

		public virtual async Task<List<POCODeviceAction>> DeviceActionGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DeviceActions/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions;
		}

		public virtual async Task<POCODeviceAction> DeviceActionGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DeviceActions/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions.FirstOrDefault();
		}

		public virtual async Task<List<POCODeviceAction>> DeviceActionGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/DeviceActions?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).DeviceActions;
		}

		public virtual async Task DeviceActionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/DeviceActions/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task DeviceActionUpdateAsync(int id,DeviceActionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/DeviceActions/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> DeviceActionCreateAsync(DeviceActionModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/DeviceActions", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task DeviceActionCreateManyAsync(List<DeviceActionModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/DeviceActions/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>d46a8578c140f07915cda6fe4297be8d</Hash>
</Codenesium>*/
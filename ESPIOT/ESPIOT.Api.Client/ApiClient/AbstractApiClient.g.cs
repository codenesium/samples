using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public abstract class AbstractApiClient
	{
		private HttpClient client;

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		public AbstractApiClient(HttpClient client)
		{
			this.client = client;
		}

		public AbstractApiClient(string apiUrl, string apiVersion)
		{
			if (string.IsNullOrWhiteSpace(apiUrl))
			{
				throw new ArgumentException("apiUrl is not set");
			}

			if (string.IsNullOrWhiteSpace(apiVersion))
			{
				throw new ArgumentException("apiVersion is not set");
			}

			if (!apiUrl.EndsWith("/"))
			{
				apiUrl += "/";
			}

			this.ApiUrl = apiUrl;
			this.ApiVersion = apiVersion;
			this.client = new HttpClient();
			this.client.BaseAddress = new Uri(apiUrl);
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<List<ApiDeviceResponseModel>> DeviceBulkInsertAsync(List<ApiDeviceRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeviceResponseModel>> DeviceCreateAsync(ApiDeviceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeviceResponseModel>> DeviceUpdateAsync(int id, ApiDeviceRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Devices/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeviceDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Devices/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeviceResponseModel> DeviceGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceResponseModel>> DeviceAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeviceResponseModel> ByDeviceByPublicId(Guid publicId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/byPublicId/{publicId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/DeviceActions/{deviceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActionBulkInsertAsync(List<ApiDeviceActionRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeviceActionResponseModel>> DeviceActionCreateAsync(ApiDeviceActionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeviceActionResponseModel>> DeviceActionUpdateAsync(int id, ApiDeviceActionRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeviceActions/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeviceActionDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeviceActions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeviceActionResponseModel> DeviceActionGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDeviceActionResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActionAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> ByDeviceActionByDeviceId(int deviceId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions/byDeviceId/{deviceId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>9c305b4057cdd54f671d00618e6ae50a</Hash>
</Codenesium>*/
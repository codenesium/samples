using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public abstract class AbstractApiClient
	{
		protected HttpClient Client { get; private set; }

		protected string ApiUrl { get; set; }

		protected string ApiVersion { get; set; }

		protected int MaxLimit { get; set; } = 1000;

		public AbstractApiClient(HttpClient client)
		{
			this.Client = client;
		}

		public AbstractApiClient(string apiUrl, string apiVersion = "1.0")
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
			this.Client = new HttpClient();
			this.Client.BaseAddress = new Uri(apiUrl);
			this.Client.DefaultRequestHeaders.Accept.Clear();
			this.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.Client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
		}

		public void SetBearerToken(string token)
		{
			this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public virtual async Task<CreateResponse<List<ApiDeviceClientResponseModel>>> DeviceBulkInsertAsync(List<ApiDeviceClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Devices/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiDeviceClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeviceClientResponseModel>> DeviceCreateAsync(ApiDeviceClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Devices", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiDeviceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeviceClientResponseModel>> DeviceUpdateAsync(int id, ApiDeviceClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Devices/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeviceClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeviceDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Devices/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeviceClientResponseModel> DeviceGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Devices/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiDeviceClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceClientResponseModel>> DeviceAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiDeviceClientResponseModel> response = new List<ApiDeviceClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Devices?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiDeviceClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiDeviceClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<ApiDeviceClientResponseModel> ByDeviceByPublicId(Guid publicId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Devices/byPublicId/{publicId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiDeviceClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionClientResponseModel>> DeviceActionsByDeviceId(int deviceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Devices/{deviceId}/DeviceActions", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiDeviceActionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiDeviceActionClientResponseModel>>> DeviceActionBulkInsertAsync(List<ApiDeviceActionClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/DeviceActions/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiDeviceActionClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiDeviceActionClientResponseModel>> DeviceActionCreateAsync(ApiDeviceActionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/DeviceActions", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiDeviceActionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDeviceActionClientResponseModel>> DeviceActionUpdateAsync(int id, ApiDeviceActionClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/DeviceActions/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiDeviceActionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DeviceActionDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/DeviceActions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDeviceActionClientResponseModel> DeviceActionGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/DeviceActions/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiDeviceActionClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDeviceActionClientResponseModel>> DeviceActionAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiDeviceActionClientResponseModel> response = new List<ApiDeviceActionClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/DeviceActions?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiDeviceActionClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiDeviceActionClientResponseModel>>(httpResponse.Content.ContentToString());
				response.AddRange(records);
				if (records.Count < this.MaxLimit)
				{
					moreRecords = false;
				}
				else
				{
					offset += this.MaxLimit;
				}
			}

			return response;
		}

		public virtual async Task<List<ApiDeviceActionClientResponseModel>> ByDeviceActionByDeviceId(int deviceId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/DeviceActions/byDeviceId/{deviceId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiDeviceActionClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		protected void HandleResponseCode(HttpResponseMessage httpResponse)
		{
			int responseCode = (int)httpResponse.StatusCode;
			if (responseCode >= 400 && responseCode != 422)
			{
				switch (responseCode)
				{
				case 401:
				{
					throw new UnauthorizedAccessException("Response from server was 401.");
				}

				case 404:
				{
					break;
				}

				default:
				{
					throw new Exception($"Received error response from server. Response code was {responseCode}. Message was {httpResponse.Content.ContentToString()}");
				}
				}
			}
		}
	}
}

/*<Codenesium>
    <Hash>efe2c2470a7cfcb0791ee444a58bfef7</Hash>
</Codenesium>*/
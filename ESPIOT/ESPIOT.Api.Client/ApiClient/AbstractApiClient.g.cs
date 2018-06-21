using Codenesium.DataConversionExtensions.AspNetCore;
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

                public AbstractApiClient(string apiUri, string apiVersion)
                {
                        if (string.IsNullOrWhiteSpace(apiUri))
                        {
                                throw new ArgumentException("apiUrl is not set");
                        }

                        if (apiUri[apiUri.Length - 1] != '/')
                        {
                                throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
                        }

                        if (string.IsNullOrWhiteSpace(apiVersion))
                        {
                                throw new ArgumentException("apiVersion is not set");
                        }

                        this.ApiUrl = apiUri;
                        this.ApiVersion = apiVersion;
                        this.client = new HttpClient();
                        this.client.BaseAddress = new Uri(apiUri);
                        this.client.DefaultRequestHeaders.Accept.Clear();
                        this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        this.client.DefaultRequestHeaders.Add("api-version", this.ApiVersion);
                }

                public virtual async Task<ApiDeviceResponseModel> DeviceCreateAsync(ApiDeviceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeviceResponseModel> DeviceUpdateAsync(int id, ApiDeviceRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Devices/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeviceDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Devices/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeviceResponseModel> DeviceGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceResponseModel>> DeviceAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceResponseModel>> DeviceBulkInsertAsync(List<ApiDeviceRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Devices/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeviceResponseModel> GetDeviceByPublicId(Guid publicId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/byPublicId/{publicId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Devices/DeviceActions/{deviceId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeviceActionResponseModel> DeviceActionCreateAsync(ApiDeviceActionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceActionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiDeviceActionResponseModel> DeviceActionUpdateAsync(int id, ApiDeviceActionRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DeviceActions/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceActionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task DeviceActionDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DeviceActions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiDeviceActionResponseModel> DeviceActionGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiDeviceActionResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActionAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceActionResponseModel>> DeviceActionBulkInsertAsync(List<ApiDeviceActionRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DeviceActions/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiDeviceActionResponseModel>> GetDeviceActionByDeviceId(int deviceId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DeviceActions/byDeviceId/{deviceId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiDeviceActionResponseModel>>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>1b88cad3a62050e8a60398f1b6cff4c5</Hash>
</Codenesium>*/
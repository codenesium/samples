using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Client
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

                public virtual async Task<ApiBucketResponseModel> BucketCreateAsync(ApiBucketRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Buckets", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBucketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBucketResponseModel> BucketUpdateAsync(int id, ApiBucketRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Buckets/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBucketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task BucketDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Buckets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiBucketResponseModel> BucketGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBucketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBucketResponseModel>> BucketAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBucketResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiBucketResponseModel>> BucketBulkInsertAsync(List<ApiBucketRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Buckets/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiBucketResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBucketResponseModel> GetBucketGetExternalId(Guid externalId)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets/getExternalId/{externalId}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBucketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiBucketResponseModel> GetBucketGetName(string name)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets/getName/{name}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiBucketResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFileResponseModel> FileCreateAsync(ApiFileRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Files", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFileResponseModel> FileUpdateAsync(int id, ApiFileRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Files/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task FileDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Files/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiFileResponseModel> FileGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFileResponseModel>> FileAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFileResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFileResponseModel>> FileBulkInsertAsync(List<ApiFileRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Files/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFileResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFileTypeResponseModel> FileTypeCreateAsync(ApiFileTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/FileTypes", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiFileTypeResponseModel> FileTypeUpdateAsync(int id, ApiFileTypeRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/FileTypes/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task FileTypeDeleteAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/FileTypes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiFileTypeResponseModel> FileTypeGetAsync(int id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiFileTypeResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFileTypeResponseModel>> FileTypeAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFileTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiFileTypeResponseModel>> FileTypeBulkInsertAsync(List<ApiFileTypeRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/FileTypes/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiFileTypeResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoCreateAsync(ApiVersionInfoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoUpdateAsync(long id, ApiVersionInfoRequestModel item)
                {
                        HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task VersionInfoDeleteAsync(long id)
                {
                        HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                }

                public virtual async Task<ApiVersionInfoResponseModel> VersionInfoGetAsync(long id)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoAllAsync(int limit = 1000, int offset = 0)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?limit={limit}&offset={offset}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<List<ApiVersionInfoResponseModel>> VersionInfoBulkInsertAsync(List<ApiVersionInfoRequestModel> items)
                {
                        HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items);

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<List<ApiVersionInfoResponseModel>>(httpResponse.Content.ContentToString());
                }

                public virtual async Task<ApiVersionInfoResponseModel> GetVersionInfoGetVersion(long version)
                {
                        HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/getVersion/{version}");

                        httpResponse.EnsureSuccessStatusCode();
                        return JsonConvert.DeserializeObject<ApiVersionInfoResponseModel>(httpResponse.Content.ContentToString());
                }
        }
}

/*<Codenesium>
    <Hash>1527a694cf913b2ce16ce1ac1cd81811</Hash>
</Codenesium>*/
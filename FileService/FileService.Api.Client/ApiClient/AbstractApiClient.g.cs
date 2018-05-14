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

		public virtual async Task<POCOBucket> BucketCreateAsync(BucketModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Buckets", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBucket>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBucket> BucketUpdateAsync(int id, BucketModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Buckets/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBucket>(httpResponse.Content.ContentToString());
		}

		public virtual async Task BucketDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Buckets/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOBucket> BucketGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBucket>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBucket>> BucketAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBucket>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBucket>> BucketBulkInsertAsync(List<BucketModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Buckets/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBucket>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFile> FileCreateAsync(FileModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Files", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFile>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFile> FileUpdateAsync(int id, FileModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Files/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFile>(httpResponse.Content.ContentToString());
		}

		public virtual async Task FileDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Files/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOFile> FileGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFile>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFile>> FileAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFile>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFile>> FileBulkInsertAsync(List<FileModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Files/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFile>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFileType> FileTypeCreateAsync(FileTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/FileTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFileType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFileType> FileTypeUpdateAsync(int id, FileTypeModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/FileTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFileType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task FileTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/FileTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOFileType> FileTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFileType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFileType>> FileTypeAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFileType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFileType>> FileTypeBulkInsertAsync(List<FileTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/FileTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFileType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVersionInfo> VersionInfoCreateAsync(VersionInfoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOVersionInfo> VersionInfoUpdateAsync(long id, VersionInfoModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VersionInfoes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task VersionInfoDeleteAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<POCOVersionInfo> VersionInfoGetAsync(long id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOVersionInfo>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVersionInfo>> VersionInfoAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VersionInfoes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVersionInfo>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOVersionInfo>> VersionInfoBulkInsertAsync(List<VersionInfoModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VersionInfoes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOVersionInfo>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>a3897fd4e8dd9cfeaab8e444fdc68a43</Hash>
</Codenesium>*/
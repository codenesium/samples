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

		public virtual async Task<List<POCOBucket>> BucketSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBucket>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOBucket> BucketGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOBucket>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOBucket>> BucketGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Buckets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOBucket>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> BucketBulkInsertAsync(List<BucketModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Buckets/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<POCOFile>> FileSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFile>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFile> FileGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFile>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFile>> FileGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Files?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFile>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> FileBulkInsertAsync(List<FileModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Files/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<POCOFileType>> FileTypeSearchAsync(string query, int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFileType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<POCOFileType> FileTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<POCOFileType>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<POCOFileType>> FileTypeGetAllAsync(int offset = 0, int limit = 250)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/FileTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<POCOFileType>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<int>> FileTypeBulkInsertAsync(List<FileTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/FileTypes/BulkInsert", items);

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<List<int>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>076f40d48f2a70634b1f9a47472d35bd</Hash>
</Codenesium>*/
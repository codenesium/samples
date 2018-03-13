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

		public virtual async Task<List<POCOBucket>>BucketSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Buckets?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Buckets;
		}

		public virtual async Task<List<POCOBucket>> BucketGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Buckets/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Buckets;
		}

		public virtual async Task<POCOBucket> BucketGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Buckets/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Buckets.FirstOrDefault();
		}

		public virtual async Task<List<POCOBucket>> BucketGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Buckets?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Buckets;
		}

		public virtual async Task BucketDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Buckets/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task BucketUpdateAsync(int id,BucketModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Buckets/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> BucketCreateAsync(BucketModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Buckets", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task BucketCreateManyAsync(List<BucketModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Buckets/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOFile>>FileSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Files?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Files;
		}

		public virtual async Task<List<POCOFile>> FileGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Files/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Files;
		}

		public virtual async Task<POCOFile> FileGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Files/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Files.FirstOrDefault();
		}

		public virtual async Task<List<POCOFile>> FileGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/Files?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).Files;
		}

		public virtual async Task FileDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/Files/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task FileUpdateAsync(int id,FileModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/Files/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> FileCreateAsync(FileModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Files", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task FileCreateManyAsync(List<FileModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/Files/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<List<POCOFileType>>FileTypeSearchAsync(string query, int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/FileTypes?{query}&offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).FileTypes;
		}

		public virtual async Task<List<POCOFileType>> FileTypeGetMultipleAsync(string csvOfIds)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/FileTypes/mulitple/{csvOfIds}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).FileTypes;
		}

		public virtual async Task<POCOFileType> FileTypeGetByIdAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/FileTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).FileTypes.FirstOrDefault();
		}

		public virtual async Task<List<POCOFileType>> FileTypeGetAllAsync(int offset=0, int limit=250)
		{
			HttpResponseMessage httpResponse = await this._client.GetAsync($"api/FileTypes?offset={offset}&limit={limit}");

			httpResponse.EnsureSuccessStatusCode();
			return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ContentToString()).FileTypes;
		}

		public virtual async Task FileTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this._client.DeleteAsync($"api/FileTypes/{id}");

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task FileTypeUpdateAsync(int id,FileTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PutAsJsonAsync($"api/FileTypes/{id}", item);

			httpResponse.EnsureSuccessStatusCode();
		}

		public virtual async Task<int> FileTypeCreateAsync(FileTypeModel item)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/FileTypes", item);

			httpResponse.EnsureSuccessStatusCode();
			return Convert.ToInt32(httpResponse.Content.ContentToString());
		}

		public virtual async Task FileTypeCreateManyAsync(List<FileTypeModel> items)
		{
			HttpResponseMessage httpResponse = await this._client.PostAsJsonAsync($"api/FileTypes/CreateMany", items);

			httpResponse.EnsureSuccessStatusCode();
		}
	}
}

/*<Codenesium>
    <Hash>85f96ff4a5da97ebaeb002415d6a0624</Hash>
</Codenesium>*/
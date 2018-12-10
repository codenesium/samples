using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
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

		public virtual async Task<CreateResponse<List<ApiBadgeClientResponseModel>>> BadgeBulkInsertAsync(List<ApiBadgeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Badges/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiBadgeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBadgeClientResponseModel>> BadgeCreateAsync(ApiBadgeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Badges", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiBadgeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBadgeClientResponseModel>> BadgeUpdateAsync(int id, ApiBadgeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Badges/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiBadgeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BadgeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Badges/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBadgeClientResponseModel> BadgeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Badges/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiBadgeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBadgeClientResponseModel>> BadgeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiBadgeClientResponseModel> response = new List<ApiBadgeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Badges?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiBadgeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiBadgeClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiCommentClientResponseModel>>> CommentBulkInsertAsync(List<ApiCommentClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Comments/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiCommentClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCommentClientResponseModel>> CommentCreateAsync(ApiCommentClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Comments", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiCommentClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCommentClientResponseModel>> CommentUpdateAsync(int id, ApiCommentClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Comments/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiCommentClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CommentDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Comments/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommentClientResponseModel> CommentGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Comments/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiCommentClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommentClientResponseModel>> CommentAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiCommentClientResponseModel> response = new List<ApiCommentClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Comments?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiCommentClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiCommentClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiLinkTypeClientResponseModel>>> LinkTypeBulkInsertAsync(List<ApiLinkTypeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/LinkTypes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiLinkTypeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkTypeClientResponseModel>> LinkTypeCreateAsync(ApiLinkTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/LinkTypes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkTypeClientResponseModel>> LinkTypeUpdateAsync(int id, ApiLinkTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/LinkTypes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkTypeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/LinkTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkTypeClientResponseModel> LinkTypeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/LinkTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiLinkTypeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkTypeClientResponseModel>> LinkTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiLinkTypeClientResponseModel> response = new List<ApiLinkTypeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/LinkTypes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiLinkTypeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiLinkTypeClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiPostHistoryClientResponseModel>>> PostHistoryBulkInsertAsync(List<ApiPostHistoryClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostHistories/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPostHistoryClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostHistoryClientResponseModel>> PostHistoryCreateAsync(ApiPostHistoryClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostHistories", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPostHistoryClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryClientResponseModel>> PostHistoryUpdateAsync(int id, ApiPostHistoryClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/PostHistories/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostHistoryClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostHistoryDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/PostHistories/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostHistoryClientResponseModel> PostHistoryGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostHistories/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPostHistoryClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryClientResponseModel>> PostHistoryAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPostHistoryClientResponseModel> response = new List<ApiPostHistoryClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostHistories?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPostHistoryClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPostHistoryClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiPostHistoryTypeClientResponseModel>>> PostHistoryTypeBulkInsertAsync(List<ApiPostHistoryTypeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostHistoryTypes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPostHistoryTypeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypeClientResponseModel>> PostHistoryTypeCreateAsync(ApiPostHistoryTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostHistoryTypes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPostHistoryTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypeClientResponseModel>> PostHistoryTypeUpdateAsync(int id, ApiPostHistoryTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/PostHistoryTypes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostHistoryTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostHistoryTypeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/PostHistoryTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostHistoryTypeClientResponseModel> PostHistoryTypeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostHistoryTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPostHistoryTypeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryTypeClientResponseModel>> PostHistoryTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPostHistoryTypeClientResponseModel> response = new List<ApiPostHistoryTypeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostHistoryTypes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPostHistoryTypeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPostHistoryTypeClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiPostLinkClientResponseModel>>> PostLinkBulkInsertAsync(List<ApiPostLinkClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostLinks/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPostLinkClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostLinkClientResponseModel>> PostLinkCreateAsync(ApiPostLinkClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostLinks", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPostLinkClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostLinkClientResponseModel>> PostLinkUpdateAsync(int id, ApiPostLinkClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/PostLinks/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostLinkClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostLinkDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/PostLinks/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostLinkClientResponseModel> PostLinkGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostLinks/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPostLinkClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostLinkClientResponseModel>> PostLinkAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPostLinkClientResponseModel> response = new List<ApiPostLinkClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostLinks?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPostLinkClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPostLinkClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiPostClientResponseModel>>> PostBulkInsertAsync(List<ApiPostClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Posts/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPostClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostClientResponseModel>> PostCreateAsync(ApiPostClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Posts", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPostClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostClientResponseModel>> PostUpdateAsync(int id, ApiPostClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Posts/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Posts/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostClientResponseModel> PostGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Posts/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPostClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostClientResponseModel>> PostAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPostClientResponseModel> response = new List<ApiPostClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Posts?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPostClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPostClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiPostClientResponseModel>> ByPostByOwnerUserId(int? ownerUserId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Posts/byOwnerUserId/{ownerUserId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiPostClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiPostTypeClientResponseModel>>> PostTypeBulkInsertAsync(List<ApiPostTypeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostTypes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiPostTypeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostTypeClientResponseModel>> PostTypeCreateAsync(ApiPostTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/PostTypes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiPostTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostTypeClientResponseModel>> PostTypeUpdateAsync(int id, ApiPostTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/PostTypes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostTypeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/PostTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostTypeClientResponseModel> PostTypeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiPostTypeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostTypeClientResponseModel>> PostTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiPostTypeClientResponseModel> response = new List<ApiPostTypeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/PostTypes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiPostTypeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiPostTypeClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiTagClientResponseModel>>> TagBulkInsertAsync(List<ApiTagClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Tags/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiTagClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTagClientResponseModel>> TagCreateAsync(ApiTagClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Tags", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiTagClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTagClientResponseModel>> TagUpdateAsync(int id, ApiTagClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Tags/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiTagClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TagDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Tags/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTagClientResponseModel> TagGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Tags/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiTagClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagClientResponseModel>> TagAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiTagClientResponseModel> response = new List<ApiTagClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Tags?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiTagClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiTagClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiUserClientResponseModel>>> UserBulkInsertAsync(List<ApiUserClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Users/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiUserClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserClientResponseModel>> UserCreateAsync(ApiUserClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Users", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserClientResponseModel>> UserUpdateAsync(int id, ApiUserClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Users/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Users/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserClientResponseModel> UserGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Users/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiUserClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserClientResponseModel>> UserAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiUserClientResponseModel> response = new List<ApiUserClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Users?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiUserClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiUserClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<CreateResponse<List<ApiVoteClientResponseModel>>> VoteBulkInsertAsync(List<ApiVoteClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Votes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiVoteClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVoteClientResponseModel>> VoteCreateAsync(ApiVoteClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/Votes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiVoteClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVoteClientResponseModel>> VoteUpdateAsync(int id, ApiVoteClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/Votes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiVoteClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VoteDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/Votes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVoteClientResponseModel> VoteGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Votes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiVoteClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteClientResponseModel>> VoteAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiVoteClientResponseModel> response = new List<ApiVoteClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Votes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiVoteClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiVoteClientResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiVoteClientResponseModel>> ByVoteByUserId(int? userId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/Votes/byUserId/{userId}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<List<ApiVoteClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<List<ApiVoteTypeClientResponseModel>>> VoteTypeBulkInsertAsync(List<ApiVoteTypeClientRequestModel> items, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/VoteTypes/BulkInsert", items, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<List<ApiVoteTypeClientResponseModel>>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVoteTypeClientResponseModel>> VoteTypeCreateAsync(ApiVoteTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PostAsJsonAsync($"api/VoteTypes", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<CreateResponse<ApiVoteTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVoteTypeClientResponseModel>> VoteTypeUpdateAsync(int id, ApiVoteTypeClientRequestModel item, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.PutAsJsonAsync($"api/VoteTypes/{id}", item, cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<UpdateResponse<ApiVoteTypeClientResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VoteTypeDeleteAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.DeleteAsync($"api/VoteTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVoteTypeClientResponseModel> VoteTypeGetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/VoteTypes/{id}", cancellationToken).ConfigureAwait(false);

			this.HandleResponseCode(httpResponse);
			return JsonConvert.DeserializeObject<ApiVoteTypeClientResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteTypeClientResponseModel>> VoteTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			int offset = 0;
			bool moreRecords = true;
			List<ApiVoteTypeClientResponseModel> response = new List<ApiVoteTypeClientResponseModel>();
			while (moreRecords)
			{
				HttpResponseMessage httpResponse = await this.Client.GetAsync($"api/VoteTypes?limit={this.MaxLimit}&offset={offset}", cancellationToken).ConfigureAwait(false);

				this.HandleResponseCode(httpResponse);
				List<ApiVoteTypeClientResponseModel> records = JsonConvert.DeserializeObject<List<ApiVoteTypeClientResponseModel>>(httpResponse.Content.ContentToString());
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
    <Hash>f75d055ada7347c6013663de4d415b60</Hash>
</Codenesium>*/
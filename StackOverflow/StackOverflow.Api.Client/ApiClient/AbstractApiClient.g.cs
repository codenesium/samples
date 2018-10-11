using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
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

		public virtual async Task<List<ApiBadgeResponseModel>> BadgeBulkInsertAsync(List<ApiBadgeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Badges/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBadgeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiBadgeResponseModel>> BadgeCreateAsync(ApiBadgeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Badges", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBadgeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBadgeResponseModel>> BadgeUpdateAsync(int id, ApiBadgeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Badges/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBadgeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BadgeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Badges/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBadgeResponseModel> BadgeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Badges/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBadgeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBadgeResponseModel>> BadgeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Badges?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBadgeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommentResponseModel>> CommentBulkInsertAsync(List<ApiCommentRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Comments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCommentResponseModel>> CommentCreateAsync(ApiCommentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Comments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCommentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCommentResponseModel>> CommentUpdateAsync(int id, ApiCommentRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Comments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCommentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CommentDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Comments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommentResponseModel> CommentGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Comments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCommentResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommentResponseModel>> CommentAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Comments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommentResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkTypeResponseModel>> LinkTypeBulkInsertAsync(List<ApiLinkTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkTypeResponseModel>> LinkTypeCreateAsync(ApiLinkTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkTypeResponseModel>> LinkTypeUpdateAsync(int id, ApiLinkTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkTypeResponseModel> LinkTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkTypeResponseModel>> LinkTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryResponseModel>> PostHistoryBulkInsertAsync(List<ApiPostHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostHistoryResponseModel>> PostHistoryCreateAsync(ApiPostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistories", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryResponseModel>> PostHistoryUpdateAsync(int id, ApiPostHistoryRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostHistories/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostHistoryDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostHistoryResponseModel> PostHistoryGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistories/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostHistoryResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryResponseModel>> PostHistoryAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistories?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryTypeResponseModel>> PostHistoryTypeBulkInsertAsync(List<ApiPostHistoryTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistoryTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypeResponseModel>> PostHistoryTypeCreateAsync(ApiPostHistoryTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistoryTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostHistoryTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypeResponseModel>> PostHistoryTypeUpdateAsync(int id, ApiPostHistoryTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostHistoryTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostHistoryTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostHistoryTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostHistoryTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostHistoryTypeResponseModel> PostHistoryTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistoryTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostHistoryTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryTypeResponseModel>> PostHistoryTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistoryTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostLinkResponseModel>> PostLinkBulkInsertAsync(List<ApiPostLinkRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostLinks/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostLinkResponseModel>> PostLinkCreateAsync(ApiPostLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostLinks", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostLinkResponseModel>> PostLinkUpdateAsync(int id, ApiPostLinkRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostLinks/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostLinkDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostLinks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostLinkResponseModel> PostLinkGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostLinks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostLinkResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostLinkResponseModel>> PostLinkAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostLinks?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostLinkResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostResponseModel>> PostBulkInsertAsync(List<ApiPostRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Posts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostResponseModel>> PostCreateAsync(ApiPostRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Posts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostResponseModel>> PostUpdateAsync(int id, ApiPostRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Posts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Posts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostResponseModel> PostGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Posts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostResponseModel>> PostAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Posts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostResponseModel>> ByPostByOwnerUserId(int? ownerUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Posts/byOwnerUserId/{ownerUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostTypeResponseModel>> PostTypeBulkInsertAsync(List<ApiPostTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostTypeResponseModel>> PostTypeCreateAsync(ApiPostTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostTypeResponseModel>> PostTypeUpdateAsync(int id, ApiPostTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostTypeResponseModel> PostTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostTypeResponseModel>> PostTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagResponseModel>> TagBulkInsertAsync(List<ApiTagRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tags/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTagResponseModel>> TagCreateAsync(ApiTagRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tags", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTagResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTagResponseModel>> TagUpdateAsync(int id, ApiTagRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tags/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTagResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TagDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tags/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTagResponseModel> TagGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tags/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTagResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagResponseModel>> TagAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tags?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserBulkInsertAsync(List<ApiUserRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> UserCreateAsync(ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> UserUpdateAsync(int id, ApiUserRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Users/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UserDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUserResponseModel> UserGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUserResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> UserAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteResponseModel>> VoteBulkInsertAsync(List<ApiVoteRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Votes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVoteResponseModel>> VoteCreateAsync(ApiVoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Votes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVoteResponseModel>> VoteUpdateAsync(int id, ApiVoteRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Votes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VoteDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Votes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVoteResponseModel> VoteGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Votes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVoteResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteResponseModel>> VoteAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Votes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteResponseModel>> ByVoteByUserId(int? userId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Votes/byUserId/{userId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteTypeResponseModel>> VoteTypeBulkInsertAsync(List<ApiVoteTypeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VoteTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVoteTypeResponseModel>> VoteTypeCreateAsync(ApiVoteTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VoteTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVoteTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVoteTypeResponseModel>> VoteTypeUpdateAsync(int id, ApiVoteTypeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VoteTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVoteTypeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VoteTypeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VoteTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVoteTypeResponseModel> VoteTypeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VoteTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVoteTypeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteTypeResponseModel>> VoteTypeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VoteTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteTypeResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>739dc55b0467b65a51cdd313f9d91294</Hash>
</Codenesium>*/
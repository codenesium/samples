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

		public virtual async Task<CreateResponse<ApiBadgesResponseModel>> BadgesCreateAsync(ApiBadgesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Badges", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiBadgesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiBadgesResponseModel>> BadgesUpdateAsync(int id, ApiBadgesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Badges/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiBadgesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> BadgesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Badges/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiBadgesResponseModel> BadgesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Badges/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiBadgesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBadgesResponseModel>> BadgesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Badges?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBadgesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiBadgesResponseModel>> BadgesBulkInsertAsync(List<ApiBadgesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Badges/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiBadgesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiCommentsResponseModel>> CommentsCreateAsync(ApiCommentsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Comments", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiCommentsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiCommentsResponseModel>> CommentsUpdateAsync(int id, ApiCommentsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Comments/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiCommentsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> CommentsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Comments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiCommentsResponseModel> CommentsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Comments/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiCommentsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommentsResponseModel>> CommentsAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Comments?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommentsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiCommentsResponseModel>> CommentsBulkInsertAsync(List<ApiCommentsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Comments/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiCommentsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLinkTypesResponseModel>> LinkTypesCreateAsync(ApiLinkTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLinkTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLinkTypesResponseModel>> LinkTypesUpdateAsync(int id, ApiLinkTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/LinkTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLinkTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LinkTypesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/LinkTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLinkTypesResponseModel> LinkTypesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLinkTypesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkTypesResponseModel>> LinkTypesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/LinkTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLinkTypesResponseModel>> LinkTypesBulkInsertAsync(List<ApiLinkTypesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/LinkTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLinkTypesResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiPostHistoryResponseModel>> PostHistoryBulkInsertAsync(List<ApiPostHistoryRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistories/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypesResponseModel>> PostHistoryTypesCreateAsync(ApiPostHistoryTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistoryTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostHistoryTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypesResponseModel>> PostHistoryTypesUpdateAsync(int id, ApiPostHistoryTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostHistoryTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostHistoryTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostHistoryTypesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostHistoryTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostHistoryTypesResponseModel> PostHistoryTypesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistoryTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostHistoryTypesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryTypesResponseModel>> PostHistoryTypesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostHistoryTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostHistoryTypesResponseModel>> PostHistoryTypesBulkInsertAsync(List<ApiPostHistoryTypesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostHistoryTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostHistoryTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostLinksResponseModel>> PostLinksCreateAsync(ApiPostLinksRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostLinks", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostLinksResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostLinksResponseModel>> PostLinksUpdateAsync(int id, ApiPostLinksRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostLinks/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostLinksResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostLinksDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostLinks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostLinksResponseModel> PostLinksGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostLinks/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostLinksResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostLinksResponseModel>> PostLinksAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostLinks?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostLinksResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostLinksResponseModel>> PostLinksBulkInsertAsync(List<ApiPostLinksRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostLinks/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostLinksResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostsResponseModel>> PostsCreateAsync(ApiPostsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Posts", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostsResponseModel>> PostsUpdateAsync(int id, ApiPostsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Posts/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Posts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostsResponseModel> PostsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Posts/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostsResponseModel>> PostsAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Posts?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostsResponseModel>> PostsBulkInsertAsync(List<ApiPostsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Posts/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiPostTypesResponseModel>> PostTypesCreateAsync(ApiPostTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiPostTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiPostTypesResponseModel>> PostTypesUpdateAsync(int id, ApiPostTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/PostTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiPostTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> PostTypesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/PostTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiPostTypesResponseModel> PostTypesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiPostTypesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostTypesResponseModel>> PostTypesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/PostTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiPostTypesResponseModel>> PostTypesBulkInsertAsync(List<ApiPostTypesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/PostTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiPostTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTagsResponseModel>> TagsCreateAsync(ApiTagsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tags", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTagsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTagsResponseModel>> TagsUpdateAsync(int id, ApiTagsRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tags/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTagsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TagsDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tags/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTagsResponseModel> TagsGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tags/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTagsResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagsResponseModel>> TagsAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tags?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTagsResponseModel>> TagsBulkInsertAsync(List<ApiTagsRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tags/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTagsResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiUsersResponseModel>> UsersCreateAsync(ApiUsersRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiUsersResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiUsersResponseModel>> UsersUpdateAsync(int id, ApiUsersRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Users/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiUsersResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> UsersDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiUsersResponseModel> UsersGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiUsersResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUsersResponseModel>> UsersAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUsersResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUsersResponseModel>> UsersBulkInsertAsync(List<ApiUsersRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUsersResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVotesResponseModel>> VotesCreateAsync(ApiVotesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Votes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVotesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVotesResponseModel>> VotesUpdateAsync(int id, ApiVotesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Votes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVotesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VotesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Votes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVotesResponseModel> VotesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Votes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVotesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVotesResponseModel>> VotesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Votes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVotesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVotesResponseModel>> VotesBulkInsertAsync(List<ApiVotesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Votes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVotesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiVoteTypesResponseModel>> VoteTypesCreateAsync(ApiVoteTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VoteTypes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiVoteTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiVoteTypesResponseModel>> VoteTypesUpdateAsync(int id, ApiVoteTypesRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/VoteTypes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiVoteTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> VoteTypesDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/VoteTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiVoteTypesResponseModel> VoteTypesGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VoteTypes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiVoteTypesResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteTypesResponseModel>> VoteTypesAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/VoteTypes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteTypesResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiVoteTypesResponseModel>> VoteTypesBulkInsertAsync(List<ApiVoteTypesRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/VoteTypes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiVoteTypesResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>4f934223ced6b14b40f943032049cd53</Hash>
</Codenesium>*/
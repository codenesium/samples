using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
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

		public virtual async Task<CreateResponse<ApiDirectTweetResponseModel>> DirectTweetCreateAsync(ApiDirectTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DirectTweets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiDirectTweetResponseModel>> DirectTweetUpdateAsync(int id, ApiDirectTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/DirectTweets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> DirectTweetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/DirectTweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiDirectTweetResponseModel> DirectTweetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DirectTweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiDirectTweetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDirectTweetResponseModel>> DirectTweetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DirectTweets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDirectTweetResponseModel>> DirectTweetBulkInsertAsync(List<ApiDirectTweetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/DirectTweets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDirectTweetResponseModel>> GetDirectTweetByTaggedUserId(int taggedUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/DirectTweets/byTaggedUserId/{taggedUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiFollowingResponseModel>> FollowingCreateAsync(ApiFollowingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Followings", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiFollowingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiFollowingResponseModel>> FollowingUpdateAsync(string id, ApiFollowingRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Followings/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiFollowingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> FollowingDeleteAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Followings/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiFollowingResponseModel> FollowingGetAsync(string id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Followings/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiFollowingResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFollowingResponseModel>> FollowingAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Followings?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFollowingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiFollowingResponseModel>> FollowingBulkInsertAsync(List<ApiFollowingRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Followings/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiFollowingResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLikeResponseModel>> LikeCreateAsync(ApiLikeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Likes", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLikeResponseModel>> LikeUpdateAsync(int id, ApiLikeRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Likes/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LikeDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Likes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLikeResponseModel> LikeGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Likes/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLikeResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLikeResponseModel>> LikeAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Likes?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLikeResponseModel>> LikeBulkInsertAsync(List<ApiLikeRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Likes/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLikeResponseModel>> GetLikeByLikerUserId(int likerUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Likes/byLikerUserId/{likerUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLikeResponseModel>> GetLikeByTweetId(int tweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Likes/byTweetId/{tweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> LocationCreateAsync(ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiLocationResponseModel>> LocationUpdateAsync(int id, ApiLocationRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Locations/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> LocationDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Locations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiLocationResponseModel> LocationGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiLocationResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLocationResponseModel>> LocationBulkInsertAsync(List<ApiLocationRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Locations/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLocationResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTweetResponseModel>> Tweets(int locationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/Tweets/{locationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> Users(int locationLocationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Locations/Users/{locationLocationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMessageResponseModel>> MessageCreateAsync(ApiMessageRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Messages", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMessageResponseModel>> MessageUpdateAsync(int id, ApiMessageRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Messages/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MessageDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Messages/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMessageResponseModel> MessageGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messages/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMessageResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessageResponseModel>> MessageAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messages?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessageResponseModel>> MessageBulkInsertAsync(List<ApiMessageRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Messages/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessageResponseModel>> GetMessageBySenderUserId(int? senderUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messages/bySenderUserId/{senderUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> Messengers(int messageId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messages/Messengers/{messageId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiMessengerResponseModel>> MessengerCreateAsync(ApiMessengerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Messengers", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiMessengerResponseModel>> MessengerUpdateAsync(int id, ApiMessengerRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Messengers/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> MessengerDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Messengers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiMessengerResponseModel> MessengerGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messengers/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiMessengerResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> MessengerAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messengers?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> MessengerBulkInsertAsync(List<ApiMessengerRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Messengers/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> GetMessengerByMessageId(int? messageId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messengers/byMessageId/{messageId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> GetMessengerByToUserId(int toUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messengers/byToUserId/{toUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessengerResponseModel>> GetMessengerByUserId(int? userId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Messengers/byUserId/{userId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessengerResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiQuoteTweetResponseModel>> QuoteTweetCreateAsync(ApiQuoteTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/QuoteTweets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiQuoteTweetResponseModel>> QuoteTweetUpdateAsync(int id, ApiQuoteTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/QuoteTweets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> QuoteTweetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/QuoteTweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiQuoteTweetResponseModel> QuoteTweetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/QuoteTweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiQuoteTweetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> QuoteTweetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/QuoteTweets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> QuoteTweetBulkInsertAsync(List<ApiQuoteTweetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/QuoteTweets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> GetQuoteTweetByRetweeterUserId(int retweeterUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/QuoteTweets/byRetweeterUserId/{retweeterUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> GetQuoteTweetBySourceTweetId(int sourceTweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/QuoteTweets/bySourceTweetId/{sourceTweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiReplyResponseModel>> ReplyCreateAsync(ApiReplyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Replies", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiReplyResponseModel>> ReplyUpdateAsync(int id, ApiReplyRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Replies/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> ReplyDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Replies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiReplyResponseModel> ReplyGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Replies/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiReplyResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReplyResponseModel>> ReplyAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Replies?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReplyResponseModel>> ReplyBulkInsertAsync(List<ApiReplyRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Replies/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReplyResponseModel>> GetReplyByReplierUserId(int replierUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Replies/byReplierUserId/{replierUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiRetweetResponseModel>> RetweetCreateAsync(ApiRetweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Retweets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiRetweetResponseModel>> RetweetUpdateAsync(int id, ApiRetweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Retweets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> RetweetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Retweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiRetweetResponseModel> RetweetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Retweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiRetweetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRetweetResponseModel>> RetweetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Retweets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRetweetResponseModel>> RetweetBulkInsertAsync(List<ApiRetweetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Retweets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRetweetResponseModel>> GetRetweetByRetwitterUserId(int? retwitterUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Retweets/byRetwitterUserId/{retwitterUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRetweetResponseModel>> GetRetweetByTweetTweetId(int tweetTweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Retweets/byTweetTweetId/{tweetTweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<CreateResponse<ApiTweetResponseModel>> TweetCreateAsync(ApiTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tweets", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<CreateResponse<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<UpdateResponse<ApiTweetResponseModel>> TweetUpdateAsync(int id, ApiTweetRequestModel item)
		{
			HttpResponseMessage httpResponse = await this.client.PutAsJsonAsync($"api/Tweets/{id}", item).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<UpdateResponse<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ActionResponse> TweetDeleteAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.DeleteAsync($"api/Tweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ActionResponse>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<ApiTweetResponseModel> TweetGetAsync(int id)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/{id}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ApiTweetResponseModel>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTweetResponseModel>> TweetAllAsync(int limit = 1000, int offset = 0)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets?limit={limit}&offset={offset}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTweetResponseModel>> TweetBulkInsertAsync(List<ApiTweetRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Tweets/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTweetResponseModel>> GetTweetByLocationId(int locationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/byLocationId/{locationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiTweetResponseModel>> GetTweetByUserUserId(int userUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/byUserUserId/{userUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiLikeResponseModel>> Likes(int tweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/Likes/{tweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiLikeResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiQuoteTweetResponseModel>> QuoteTweets(int sourceTweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/QuoteTweets/{sourceTweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiQuoteTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiRetweetResponseModel>> Retweets(int tweetTweetId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Tweets/Retweets/{tweetTweetId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiRetweetResponseModel>>(httpResponse.Content.ContentToString());
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

		public virtual async Task<List<ApiUserResponseModel>> UserBulkInsertAsync(List<ApiUserRequestModel> items)
		{
			HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync($"api/Users/BulkInsert", items).ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiUserResponseModel>> GetUserByLocationLocationId(int locationLocationId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/byLocationLocationId/{locationLocationId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiUserResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiDirectTweetResponseModel>> DirectTweets(int taggedUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/DirectTweets/{taggedUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiDirectTweetResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiMessageResponseModel>> Messages(int senderUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/Messages/{senderUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiMessageResponseModel>>(httpResponse.Content.ContentToString());
		}

		public virtual async Task<List<ApiReplyResponseModel>> Replies(int replierUserId)
		{
			HttpResponseMessage httpResponse = await this.client.GetAsync($"api/Users/Replies/{replierUserId}").ConfigureAwait(false);

			return JsonConvert.DeserializeObject<List<ApiReplyResponseModel>>(httpResponse.Content.ContentToString());
		}
	}
}

/*<Codenesium>
    <Hash>8dd82ed623c6c67a38a10dd0aff5252a</Hash>
</Codenesium>*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.DirectTweets.ForEach(x => this.AddDirectTweet(x));
			from.Followings.ForEach(x => this.AddFollowing(x));
			from.Likes.ForEach(x => this.AddLike(x));
			from.Locations.ForEach(x => this.AddLocation(x));
			from.Messages.ForEach(x => this.AddMessage(x));
			from.Messengers.ForEach(x => this.AddMessenger(x));
			from.QuoteTweets.ForEach(x => this.AddQuoteTweet(x));
			from.Replies.ForEach(x => this.AddReply(x));
			from.Retweets.ForEach(x => this.AddRetweet(x));
			from.Tweets.ForEach(x => this.AddTweet(x));
			from.Users.ForEach(x => this.AddUser(x));
		}

		public List<ApiDirectTweetResponseModel> DirectTweets { get; private set; } = new List<ApiDirectTweetResponseModel>();

		public List<ApiFollowingResponseModel> Followings { get; private set; } = new List<ApiFollowingResponseModel>();

		public List<ApiLikeResponseModel> Likes { get; private set; } = new List<ApiLikeResponseModel>();

		public List<ApiLocationResponseModel> Locations { get; private set; } = new List<ApiLocationResponseModel>();

		public List<ApiMessageResponseModel> Messages { get; private set; } = new List<ApiMessageResponseModel>();

		public List<ApiMessengerResponseModel> Messengers { get; private set; } = new List<ApiMessengerResponseModel>();

		public List<ApiQuoteTweetResponseModel> QuoteTweets { get; private set; } = new List<ApiQuoteTweetResponseModel>();

		public List<ApiReplyResponseModel> Replies { get; private set; } = new List<ApiReplyResponseModel>();

		public List<ApiRetweetResponseModel> Retweets { get; private set; } = new List<ApiRetweetResponseModel>();

		public List<ApiTweetResponseModel> Tweets { get; private set; } = new List<ApiTweetResponseModel>();

		public List<ApiUserResponseModel> Users { get; private set; } = new List<ApiUserResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeDirectTweetsValue { get; private set; } = true;

		public bool ShouldSerializeDirectTweets()
		{
			return this.ShouldSerializeDirectTweetsValue;
		}

		public void AddDirectTweet(ApiDirectTweetResponseModel item)
		{
			if (!this.DirectTweets.Any(x => x.TweetId == item.TweetId))
			{
				this.DirectTweets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFollowingsValue { get; private set; } = true;

		public bool ShouldSerializeFollowings()
		{
			return this.ShouldSerializeFollowingsValue;
		}

		public void AddFollowing(ApiFollowingResponseModel item)
		{
			if (!this.Followings.Any(x => x.UserId == item.UserId))
			{
				this.Followings.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLikesValue { get; private set; } = true;

		public bool ShouldSerializeLikes()
		{
			return this.ShouldSerializeLikesValue;
		}

		public void AddLike(ApiLikeResponseModel item)
		{
			if (!this.Likes.Any(x => x.LikeId == item.LikeId))
			{
				this.Likes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationsValue { get; private set; } = true;

		public bool ShouldSerializeLocations()
		{
			return this.ShouldSerializeLocationsValue;
		}

		public void AddLocation(ApiLocationResponseModel item)
		{
			if (!this.Locations.Any(x => x.LocationId == item.LocationId))
			{
				this.Locations.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeMessagesValue { get; private set; } = true;

		public bool ShouldSerializeMessages()
		{
			return this.ShouldSerializeMessagesValue;
		}

		public void AddMessage(ApiMessageResponseModel item)
		{
			if (!this.Messages.Any(x => x.MessageId == item.MessageId))
			{
				this.Messages.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeMessengersValue { get; private set; } = true;

		public bool ShouldSerializeMessengers()
		{
			return this.ShouldSerializeMessengersValue;
		}

		public void AddMessenger(ApiMessengerResponseModel item)
		{
			if (!this.Messengers.Any(x => x.Id == item.Id))
			{
				this.Messengers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeQuoteTweetsValue { get; private set; } = true;

		public bool ShouldSerializeQuoteTweets()
		{
			return this.ShouldSerializeQuoteTweetsValue;
		}

		public void AddQuoteTweet(ApiQuoteTweetResponseModel item)
		{
			if (!this.QuoteTweets.Any(x => x.QuoteTweetId == item.QuoteTweetId))
			{
				this.QuoteTweets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeRepliesValue { get; private set; } = true;

		public bool ShouldSerializeReplies()
		{
			return this.ShouldSerializeRepliesValue;
		}

		public void AddReply(ApiReplyResponseModel item)
		{
			if (!this.Replies.Any(x => x.ReplyId == item.ReplyId))
			{
				this.Replies.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeRetweetsValue { get; private set; } = true;

		public bool ShouldSerializeRetweets()
		{
			return this.ShouldSerializeRetweetsValue;
		}

		public void AddRetweet(ApiRetweetResponseModel item)
		{
			if (!this.Retweets.Any(x => x.Id == item.Id))
			{
				this.Retweets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTweetsValue { get; private set; } = true;

		public bool ShouldSerializeTweets()
		{
			return this.ShouldSerializeTweetsValue;
		}

		public void AddTweet(ApiTweetResponseModel item)
		{
			if (!this.Tweets.Any(x => x.TweetId == item.TweetId))
			{
				this.Tweets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeUsersValue { get; private set; } = true;

		public bool ShouldSerializeUsers()
		{
			return this.ShouldSerializeUsersValue;
		}

		public void AddUser(ApiUserResponseModel item)
		{
			if (!this.Users.Any(x => x.UserId == item.UserId))
			{
				this.Users.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.DirectTweets.Count == 0)
			{
				this.ShouldSerializeDirectTweetsValue = false;
			}

			if (this.Followings.Count == 0)
			{
				this.ShouldSerializeFollowingsValue = false;
			}

			if (this.Likes.Count == 0)
			{
				this.ShouldSerializeLikesValue = false;
			}

			if (this.Locations.Count == 0)
			{
				this.ShouldSerializeLocationsValue = false;
			}

			if (this.Messages.Count == 0)
			{
				this.ShouldSerializeMessagesValue = false;
			}

			if (this.Messengers.Count == 0)
			{
				this.ShouldSerializeMessengersValue = false;
			}

			if (this.QuoteTweets.Count == 0)
			{
				this.ShouldSerializeQuoteTweetsValue = false;
			}

			if (this.Replies.Count == 0)
			{
				this.ShouldSerializeRepliesValue = false;
			}

			if (this.Retweets.Count == 0)
			{
				this.ShouldSerializeRetweetsValue = false;
			}

			if (this.Tweets.Count == 0)
			{
				this.ShouldSerializeTweetsValue = false;
			}

			if (this.Users.Count == 0)
			{
				this.ShouldSerializeUsersValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>1774073b0e9b29b6258c997cd21cfa8e</Hash>
</Codenesium>*/
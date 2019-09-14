using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.DirectTweets.ForEach(x => this.AddDirectTweet(x));
			from.Followers.ForEach(x => this.AddFollower(x));
			from.Followings.ForEach(x => this.AddFollowing(x));
			from.Locations.ForEach(x => this.AddLocation(x));
			from.Messages.ForEach(x => this.AddMessage(x));
			from.Messengers.ForEach(x => this.AddMessenger(x));
			from.QuoteTweets.ForEach(x => this.AddQuoteTweet(x));
			from.Replies.ForEach(x => this.AddReply(x));
			from.Retweets.ForEach(x => this.AddRetweet(x));
			from.Tweets.ForEach(x => this.AddTweet(x));
			from.Users.ForEach(x => this.AddUser(x));
		}

		public List<ApiDirectTweetClientResponseModel> DirectTweets { get; private set; } = new List<ApiDirectTweetClientResponseModel>();

		public List<ApiFollowerClientResponseModel> Followers { get; private set; } = new List<ApiFollowerClientResponseModel>();

		public List<ApiFollowingClientResponseModel> Followings { get; private set; } = new List<ApiFollowingClientResponseModel>();

		public List<ApiLocationClientResponseModel> Locations { get; private set; } = new List<ApiLocationClientResponseModel>();

		public List<ApiMessageClientResponseModel> Messages { get; private set; } = new List<ApiMessageClientResponseModel>();

		public List<ApiMessengerClientResponseModel> Messengers { get; private set; } = new List<ApiMessengerClientResponseModel>();

		public List<ApiQuoteTweetClientResponseModel> QuoteTweets { get; private set; } = new List<ApiQuoteTweetClientResponseModel>();

		public List<ApiReplyClientResponseModel> Replies { get; private set; } = new List<ApiReplyClientResponseModel>();

		public List<ApiRetweetClientResponseModel> Retweets { get; private set; } = new List<ApiRetweetClientResponseModel>();

		public List<ApiTweetClientResponseModel> Tweets { get; private set; } = new List<ApiTweetClientResponseModel>();

		public List<ApiUserClientResponseModel> Users { get; private set; } = new List<ApiUserClientResponseModel>();

		public void AddDirectTweet(ApiDirectTweetClientResponseModel item)
		{
			if (!this.DirectTweets.Any(x => x.TweetId == item.TweetId))
			{
				this.DirectTweets.Add(item);
			}
		}

		public void AddFollower(ApiFollowerClientResponseModel item)
		{
			if (!this.Followers.Any(x => x.Id == item.Id))
			{
				this.Followers.Add(item);
			}
		}

		public void AddFollowing(ApiFollowingClientResponseModel item)
		{
			if (!this.Followings.Any(x => x.UserId == item.UserId))
			{
				this.Followings.Add(item);
			}
		}

		public void AddLocation(ApiLocationClientResponseModel item)
		{
			if (!this.Locations.Any(x => x.LocationId == item.LocationId))
			{
				this.Locations.Add(item);
			}
		}

		public void AddMessage(ApiMessageClientResponseModel item)
		{
			if (!this.Messages.Any(x => x.MessageId == item.MessageId))
			{
				this.Messages.Add(item);
			}
		}

		public void AddMessenger(ApiMessengerClientResponseModel item)
		{
			if (!this.Messengers.Any(x => x.Id == item.Id))
			{
				this.Messengers.Add(item);
			}
		}

		public void AddQuoteTweet(ApiQuoteTweetClientResponseModel item)
		{
			if (!this.QuoteTweets.Any(x => x.QuoteTweetId == item.QuoteTweetId))
			{
				this.QuoteTweets.Add(item);
			}
		}

		public void AddReply(ApiReplyClientResponseModel item)
		{
			if (!this.Replies.Any(x => x.ReplyId == item.ReplyId))
			{
				this.Replies.Add(item);
			}
		}

		public void AddRetweet(ApiRetweetClientResponseModel item)
		{
			if (!this.Retweets.Any(x => x.Id == item.Id))
			{
				this.Retweets.Add(item);
			}
		}

		public void AddTweet(ApiTweetClientResponseModel item)
		{
			if (!this.Tweets.Any(x => x.TweetId == item.TweetId))
			{
				this.Tweets.Add(item);
			}
		}

		public void AddUser(ApiUserClientResponseModel item)
		{
			if (!this.Users.Any(x => x.UserId == item.UserId))
			{
				this.Users.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>28aaa71911aceedffcbc62a9fea9be52</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
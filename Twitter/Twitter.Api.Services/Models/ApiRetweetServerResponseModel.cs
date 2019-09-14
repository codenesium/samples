using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiRetweetServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime? date,
			int? retwitterUserId,
			TimeSpan? time,
			int tweetTweetId)
		{
			this.Id = id;
			this.Date = date;
			this.RetwitterUserId = retwitterUserId;
			this.Time = time;
			this.TweetTweetId = tweetTweetId;
		}

		[Required]
		[JsonProperty]
		public DateTime? Date { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int? RetwitterUserId { get; private set; }

		[JsonProperty]
		public string RetwitterUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel RetwitterUserIdNavigation { get; private set; }

		public void SetRetwitterUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.RetwitterUserIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int TweetTweetId { get; private set; }

		[JsonProperty]
		public string TweetTweetIdEntity { get; private set; } = RouteConstants.Tweets;

		[JsonProperty]
		public ApiTweetServerResponseModel TweetTweetIdNavigation { get; private set; }

		public void SetTweetTweetIdNavigation(ApiTweetServerResponseModel value)
		{
			this.TweetTweetIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>dc34fbf3fc19381a94678517c431ddeb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
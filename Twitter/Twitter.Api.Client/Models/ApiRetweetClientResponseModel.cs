using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiRetweetClientResponseModel : AbstractApiClientResponseModel
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

			this.RetwitterUserIdEntity = nameof(ApiResponse.Users);

			this.TweetTweetIdEntity = nameof(ApiResponse.Tweets);
		}

		[JsonProperty]
		public ApiUserClientResponseModel RetwitterUserIdNavigation { get; private set; }

		public void SetRetwitterUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.RetwitterUserIdNavigation = value;
		}

		[JsonProperty]
		public ApiTweetClientResponseModel TweetTweetIdNavigation { get; private set; }

		public void SetTweetTweetIdNavigation(ApiTweetClientResponseModel value)
		{
			this.TweetTweetIdNavigation = value;
		}

		[JsonProperty]
		public DateTime? Date { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int? RetwitterUserId { get; private set; }

		[JsonProperty]
		public string RetwitterUserIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int TweetTweetId { get; private set; }

		[JsonProperty]
		public string TweetTweetIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>86fbb1f7a65eaf3892c05b73686c2f4f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
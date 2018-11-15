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
    <Hash>35476f5675739f3dd8ee9f88ca731776</Hash>
</Codenesium>*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiTweetClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int tweetId,
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int userUserId)
		{
			this.TweetId = tweetId;
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.UserUserId = userUserId;

			this.LocationIdEntity = nameof(ApiResponse.Locations);
			this.UserUserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int LocationId { get; private set; }

		[JsonProperty]
		public string LocationIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[JsonProperty]
		public int TweetId { get; private set; }

		[JsonProperty]
		public int UserUserId { get; private set; }

		[JsonProperty]
		public string UserUserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ab469ef2e539bd449f146b002cd0a599</Hash>
</Codenesium>*/
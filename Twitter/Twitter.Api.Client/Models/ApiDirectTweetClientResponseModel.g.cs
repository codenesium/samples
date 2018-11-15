using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiDirectTweetClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int tweetId,
			string content,
			DateTime date,
			int taggedUserId,
			TimeSpan time)
		{
			this.TweetId = tweetId;
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
			this.Time = time;

			this.TaggedUserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int TaggedUserId { get; private set; }

		[JsonProperty]
		public string TaggedUserIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[JsonProperty]
		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b477832c869898cd0b67b80b905077ca</Hash>
</Codenesium>*/
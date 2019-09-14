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
		public ApiUserClientResponseModel TaggedUserIdNavigation { get; private set; }

		public void SetTaggedUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.TaggedUserIdNavigation = value;
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
    <Hash>c81898145af8b16311ffb74e70335559</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
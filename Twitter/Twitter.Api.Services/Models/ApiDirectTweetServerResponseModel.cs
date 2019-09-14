using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiDirectTweetServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int TaggedUserId { get; private set; }

		[JsonProperty]
		public string TaggedUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel TaggedUserIdNavigation { get; private set; }

		public void SetTaggedUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.TaggedUserIdNavigation = value;
		}

		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[JsonProperty]
		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7730a0bbc7252f6dab57e55d41e84f67</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
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
		public string TaggedUserIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[JsonProperty]
		public int TweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>87bf25390d55e2d6ccb7432ebbbc1b27</Hash>
</Codenesium>*/
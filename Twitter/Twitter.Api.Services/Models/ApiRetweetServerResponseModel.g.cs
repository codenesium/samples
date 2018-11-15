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
		public string RetwitterUserIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int TweetTweetId { get; private set; }

		[JsonProperty]
		public string TweetTweetIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>b7de0d86e1a3a0ded221f2fb232f8a8d</Hash>
</Codenesium>*/
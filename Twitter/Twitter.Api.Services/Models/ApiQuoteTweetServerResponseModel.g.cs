using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiQuoteTweetServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int quoteTweetId,
			string content,
			DateTime date,
			int retweeterUserId,
			int sourceTweetId,
			TimeSpan time)
		{
			this.QuoteTweetId = quoteTweetId;
			this.Content = content;
			this.Date = date;
			this.RetweeterUserId = retweeterUserId;
			this.SourceTweetId = sourceTweetId;
			this.Time = time;
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public int QuoteTweetId { get; private set; }

		[JsonProperty]
		public int RetweeterUserId { get; private set; }

		[JsonProperty]
		public string RetweeterUserIdEntity { get; set; }

		[JsonProperty]
		public int SourceTweetId { get; private set; }

		[JsonProperty]
		public string SourceTweetIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0f26063cb4de05295672dfcef925c95d</Hash>
</Codenesium>*/
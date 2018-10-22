using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiRetweetRequestModel : AbstractApiRequestModel
	{
		public ApiRetweetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? date,
			int? retwitterUserId,
			TimeSpan? time,
			int tweetTweetId)
		{
			this.Date = date;
			this.RetwitterUserId = retwitterUserId;
			this.Time = time;
			this.TweetTweetId = tweetTweetId;
		}

		[JsonProperty]
		public DateTime? Date { get; private set; } = null;

		[JsonProperty]
		public int? RetwitterUserId { get; private set; }

		[JsonProperty]
		public TimeSpan? Time { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public int TweetTweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>65fdbe6f89f830d12f6452a621ecb98c</Hash>
</Codenesium>*/
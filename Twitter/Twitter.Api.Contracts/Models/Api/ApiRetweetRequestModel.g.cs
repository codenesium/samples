using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public DateTime? Date { get; private set; } = default(DateTime);

		[JsonProperty]
		public int? RetwitterUserId { get; private set; } = default(int);

		[JsonProperty]
		public TimeSpan? Time { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public int TweetTweetId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>2b92c7ab6d95e454c908fd91cc1c347f</Hash>
</Codenesium>*/
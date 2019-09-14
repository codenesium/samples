using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiRetweetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiRetweetClientRequestModel()
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

		[JsonProperty]
		public int TweetTweetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e74727e9019bf8ab42290690584a38ab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
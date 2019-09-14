using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiRetweetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiRetweetServerRequestModel()
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
    <Hash>53b0b2aa84dd4d2756622dd5420fed91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
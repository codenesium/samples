using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiQuoteTweetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiQuoteTweetClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int retweeterUserId,
			int sourceTweetId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.RetweeterUserId = retweeterUserId;
			this.SourceTweetId = sourceTweetId;
			this.Time = time;
		}

		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int RetweeterUserId { get; private set; }

		[JsonProperty]
		public int SourceTweetId { get; private set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>f61de442d0af8eef85ba7b05e4d431a4</Hash>
</Codenesium>*/
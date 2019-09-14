using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiQuoteTweetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiQuoteTweetServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int RetweeterUserId { get; private set; }

		[Required]
		[JsonProperty]
		public int SourceTweetId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>4f0a242707280e338dd8f722d5a9453f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
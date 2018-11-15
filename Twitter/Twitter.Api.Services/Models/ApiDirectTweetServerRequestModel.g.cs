using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiDirectTweetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDirectTweetServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int taggedUserId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
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
		public int TaggedUserId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>ca21b87426f91dbc317cf4b85a025c35</Hash>
</Codenesium>*/
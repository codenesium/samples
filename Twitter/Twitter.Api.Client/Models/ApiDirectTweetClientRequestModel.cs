using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiDirectTweetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDirectTweetClientRequestModel()
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

		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int TaggedUserId { get; private set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>3c4c2370015f6a3c4b390ffefb7875c4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
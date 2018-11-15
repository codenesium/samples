using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiReplyClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiReplyClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int replierUserId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.Time = time;
		}

		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int ReplierUserId { get; private set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>42f64d4771fbffa6a3c9540a3e5c1cc1</Hash>
</Codenesium>*/
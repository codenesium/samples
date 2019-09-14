using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiTweetClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTweetClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int userUserId)
		{
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.UserUserId = userUserId;
		}

		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int LocationId { get; private set; }

		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);

		[JsonProperty]
		public int UserUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>23f1e22722e16d904449f5dfae22653d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
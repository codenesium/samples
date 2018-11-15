using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiMessengerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiMessengerClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? date,
			int? fromUserId,
			int? messageId,
			TimeSpan? time,
			int toUserId,
			int? userId)
		{
			this.Date = date;
			this.FromUserId = fromUserId;
			this.MessageId = messageId;
			this.Time = time;
			this.ToUserId = toUserId;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime? Date { get; private set; } = null;

		[JsonProperty]
		public int? FromUserId { get; private set; } = default(int);

		[JsonProperty]
		public int? MessageId { get; private set; }

		[JsonProperty]
		public TimeSpan? Time { get; private set; } = default(TimeSpan);

		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fbc1505b35fcf49a0df56e8107831b39</Hash>
</Codenesium>*/
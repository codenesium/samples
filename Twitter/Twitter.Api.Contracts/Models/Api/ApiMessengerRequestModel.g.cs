using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiMessengerRequestModel : AbstractApiRequestModel
	{
		public ApiMessengerRequestModel()
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
		public DateTime? Date { get; private set; }

		[JsonProperty]
		public int? FromUserId { get; private set; }

		[JsonProperty]
		public int? MessageId { get; private set; }

		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[Required]
		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>95914b7f2e2a0b344913f9163e75202e</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiMessengerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiMessengerServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1f7a5ffa70e8d7467fc44eaadbd181e3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
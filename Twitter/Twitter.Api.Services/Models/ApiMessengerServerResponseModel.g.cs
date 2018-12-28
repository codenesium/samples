using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiMessengerServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime? date,
			int? fromUserId,
			int? messageId,
			TimeSpan? time,
			int toUserId,
			int? userId)
		{
			this.Id = id;
			this.Date = date;
			this.FromUserId = fromUserId;
			this.MessageId = messageId;
			this.Time = time;
			this.ToUserId = toUserId;
			this.UserId = userId;
		}

		[Required]
		[JsonProperty]
		public DateTime? Date { get; private set; }

		[Required]
		[JsonProperty]
		public int? FromUserId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int? MessageId { get; private set; }

		[JsonProperty]
		public string MessageIdEntity { get; private set; } = RouteConstants.Messages;

		[Required]
		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public string ToUserIdEntity { get; private set; } = RouteConstants.Users;

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;
	}
}

/*<Codenesium>
    <Hash>4660ec6118fab6ea9a864a65ec366209</Hash>
</Codenesium>*/
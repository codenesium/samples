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
		public string MessageIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public string ToUserIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>c3bfae735b4f47457080a4ccbfe136d4</Hash>
</Codenesium>*/
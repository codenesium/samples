using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiMessengerClientResponseModel : AbstractApiClientResponseModel
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

			this.MessageIdEntity = nameof(ApiResponse.Messages);
			this.ToUserIdEntity = nameof(ApiResponse.Users);
			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public DateTime? Date { get; private set; }

		[JsonProperty]
		public int? FromUserId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int? MessageId { get; private set; }

		[JsonProperty]
		public string MessageIdEntity { get; set; }

		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public string ToUserIdEntity { get; set; }

		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>d1cffcd57b2896fea94aa3a4ae85fe50</Hash>
</Codenesium>*/
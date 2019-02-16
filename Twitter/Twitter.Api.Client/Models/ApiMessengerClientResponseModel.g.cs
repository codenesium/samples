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
		public ApiMessageClientResponseModel MessageIdNavigation { get; private set; }

		public void SetMessageIdNavigation(ApiMessageClientResponseModel value)
		{
			this.MessageIdNavigation = value;
		}

		[JsonProperty]
		public ApiUserClientResponseModel ToUserIdNavigation { get; private set; }

		public void SetToUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.ToUserIdNavigation = value;
		}

		[JsonProperty]
		public ApiUserClientResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.UserIdNavigation = value;
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
    <Hash>5f6c02321f1239fd4efd40f65d7fd5fe</Hash>
</Codenesium>*/
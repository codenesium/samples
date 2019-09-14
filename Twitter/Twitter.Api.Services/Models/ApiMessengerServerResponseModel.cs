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

		[JsonProperty]
		public ApiMessageServerResponseModel MessageIdNavigation { get; private set; }

		public void SetMessageIdNavigation(ApiMessageServerResponseModel value)
		{
			this.MessageIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public TimeSpan? Time { get; private set; }

		[JsonProperty]
		public int ToUserId { get; private set; }

		[JsonProperty]
		public string ToUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel ToUserIdNavigation { get; private set; }

		public void SetToUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.ToUserIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.UserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>318c8df0318c5aeaba46cec3644bbb55</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
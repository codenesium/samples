using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiMessageServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int messageId,
			string content,
			int? senderUserId)
		{
			this.MessageId = messageId;
			this.Content = content;
			this.SenderUserId = senderUserId;
		}

		[Required]
		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public int MessageId { get; private set; }

		[Required]
		[JsonProperty]
		public int? SenderUserId { get; private set; }

		[JsonProperty]
		public string SenderUserIdEntity { get; private set; } = RouteConstants.Users;

		[JsonProperty]
		public ApiUserServerResponseModel SenderUserIdNavigation { get; private set; }

		public void SetSenderUserIdNavigation(ApiUserServerResponseModel value)
		{
			this.SenderUserIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>be88715d9bc634f5f77a165c90ead313</Hash>
</Codenesium>*/
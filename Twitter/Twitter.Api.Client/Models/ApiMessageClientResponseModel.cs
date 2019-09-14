using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiMessageClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int messageId,
			string content,
			int? senderUserId)
		{
			this.MessageId = messageId;
			this.Content = content;
			this.SenderUserId = senderUserId;

			this.SenderUserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public ApiUserClientResponseModel SenderUserIdNavigation { get; private set; }

		public void SetSenderUserIdNavigation(ApiUserClientResponseModel value)
		{
			this.SenderUserIdNavigation = value;
		}

		[JsonProperty]
		public string Content { get; private set; }

		[JsonProperty]
		public int MessageId { get; private set; }

		[JsonProperty]
		public int? SenderUserId { get; private set; }

		[JsonProperty]
		public string SenderUserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>c233f31abb7a4a87dad52e328e6e1cfd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
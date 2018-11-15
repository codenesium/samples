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
    <Hash>9b78976049e14d0bc966c35cd46d03bd</Hash>
</Codenesium>*/
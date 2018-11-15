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
		public string SenderUserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>fbd41b4723fda470e6a0f63360e28a2d</Hash>
</Codenesium>*/
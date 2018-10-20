using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiMessageRequestModel : AbstractApiRequestModel
	{
		public ApiMessageRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			int? senderUserId)
		{
			this.Content = content;
			this.SenderUserId = senderUserId;
		}

		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[JsonProperty]
		public int? SenderUserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>5ea3bc51bc3506dc74e6f5dd26bc3261</Hash>
</Codenesium>*/
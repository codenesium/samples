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
		public string Content { get; private set; }

		[JsonProperty]
		public int? SenderUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>03e80c60ba5b33ecb36a161320c9e134</Hash>
</Codenesium>*/
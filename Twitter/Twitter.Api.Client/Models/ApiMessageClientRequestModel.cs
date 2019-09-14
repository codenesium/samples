using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiMessageClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiMessageClientRequestModel()
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
		public int? SenderUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fd7d442290add7e7e63b47d393299667</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
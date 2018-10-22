using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int? SenderUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>685134ab7b4d6e330e2e7f1654d2b77d</Hash>
</Codenesium>*/
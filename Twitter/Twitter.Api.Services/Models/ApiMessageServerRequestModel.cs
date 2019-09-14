using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiMessageServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiMessageServerRequestModel()
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
    <Hash>9d856e180c31d502858b019adaa67a96</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
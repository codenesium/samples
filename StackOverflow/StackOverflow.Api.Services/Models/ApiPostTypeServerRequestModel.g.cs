using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostTypeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPostTypeServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string rwtype)
		{
			this.Type = rwtype;
		}

		[Required]
		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>af67eb6949f7a8a22ff6cd9f1308a690</Hash>
</Codenesium>*/
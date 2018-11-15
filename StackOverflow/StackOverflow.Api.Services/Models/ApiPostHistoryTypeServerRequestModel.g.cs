using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostHistoryTypeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPostHistoryTypeServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string type)
		{
			this.Type = type;
		}

		[Required]
		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5a07b993b2dc469ed8dc2c557e45a124</Hash>
</Codenesium>*/
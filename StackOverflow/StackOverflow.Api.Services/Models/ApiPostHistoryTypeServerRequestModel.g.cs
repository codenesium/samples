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
    <Hash>865b2179b184b017bddbcf4f190a6b52</Hash>
</Codenesium>*/
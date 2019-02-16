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
			string rwType)
		{
			this.RwType = rwType;
		}

		[Required]
		[JsonProperty]
		public string RwType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>d0c1007554782da891d9483750106603</Hash>
</Codenesium>*/
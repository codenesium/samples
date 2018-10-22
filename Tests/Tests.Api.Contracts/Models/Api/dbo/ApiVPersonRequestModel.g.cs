using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiVPersonRequestModel : AbstractApiRequestModel
	{
		public ApiVPersonRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string personName)
		{
			this.PersonName = personName;
		}

		[Required]
		[JsonProperty]
		public string PersonName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>407b35961cd2f3d17fb877cf2738e229</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    <Hash>eb937ef47ef1ae9a4601c3af9d6b8dbd</Hash>
</Codenesium>*/
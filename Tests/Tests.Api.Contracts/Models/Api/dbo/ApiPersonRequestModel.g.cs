using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiPersonRequestModel : AbstractApiRequestModel
	{
		public ApiPersonRequestModel()
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
    <Hash>695cafbc6cc7de688b75a9abe23b2b5a</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5946b51074607ba1660e7a5b93489b8d</Hash>
</Codenesium>*/
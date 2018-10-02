using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiColumnSameAsFKTableRequestModel : AbstractApiRequestModel
	{
		public ApiColumnSameAsFKTableRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int person,
			int personId)
		{
			this.Person = person;
			this.PersonId = personId;
		}

		[Required]
		[JsonProperty]
		public int Person { get; private set; }

		[Required]
		[JsonProperty]
		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e3ddd839747377250750bfd4564f837f</Hash>
</Codenesium>*/
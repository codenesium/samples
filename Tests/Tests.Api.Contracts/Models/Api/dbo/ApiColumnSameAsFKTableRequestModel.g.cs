using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int Person { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PersonId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>6a93262ae1028c644f57e15eada6a038</Hash>
</Codenesium>*/
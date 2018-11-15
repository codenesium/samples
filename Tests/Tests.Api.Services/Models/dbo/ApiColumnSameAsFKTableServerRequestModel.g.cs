using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiColumnSameAsFKTableServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiColumnSameAsFKTableServerRequestModel()
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
    <Hash>8fa070ef1a27265761832e6889d2ba9b</Hash>
</Codenesium>*/
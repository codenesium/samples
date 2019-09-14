using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiColumnSameAsFKTableClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiColumnSameAsFKTableClientRequestModel()
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

		[JsonProperty]
		public int Person { get; private set; }

		[JsonProperty]
		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f1653a96e81391cdf59307dd74ca245b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
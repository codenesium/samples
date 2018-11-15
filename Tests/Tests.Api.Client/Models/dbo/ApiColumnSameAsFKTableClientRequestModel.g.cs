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
		public int Person { get; private set; } = default(int);

		[JsonProperty]
		public int PersonId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>44826d612d70e9ce31547db8163792de</Hash>
</Codenesium>*/
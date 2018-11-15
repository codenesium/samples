using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiBreedClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiBreedClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name)
		{
			this.Name = name;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4e4e51e23e30a62b155a3fa45122a1d2</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Client
{
	public partial class ApiPenClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPenClientRequestModel()
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
    <Hash>cb2de553d1955173a40862301c7f6070</Hash>
</Codenesium>*/
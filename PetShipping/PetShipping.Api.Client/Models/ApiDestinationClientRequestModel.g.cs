using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiDestinationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDestinationClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string name,
			int order)
		{
			this.CountryId = countryId;
			this.Name = name;
			this.Order = order;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int Order { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>048ad37b985446d70541da1449b3e459</Hash>
</Codenesium>*/
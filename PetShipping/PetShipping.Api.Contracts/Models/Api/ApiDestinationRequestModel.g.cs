using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiDestinationRequestModel : AbstractApiRequestModel
	{
		public ApiDestinationRequestModel()
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
		public string Name { get; private set; }

		[JsonProperty]
		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>01336c089f74227970d5d04a0fe9c5d7</Hash>
</Codenesium>*/
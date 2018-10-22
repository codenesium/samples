using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int Order { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>659b60303fd32bd5f9bcf26409f003f1</Hash>
</Codenesium>*/
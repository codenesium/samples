using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiDestinationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDestinationServerRequestModel()
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
    <Hash>56d6e97e34ff051ae006c7756d2e8230</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
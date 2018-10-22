using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiProvinceRequestModel : AbstractApiRequestModel
	{
		public ApiProvinceRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string name)
		{
			this.CountryId = countryId;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>b80e976b42b0eecb1742bfb9b4a84c5f</Hash>
</Codenesium>*/
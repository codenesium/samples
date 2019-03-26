using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCountryRegionClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			string countryRegionCode,
			DateTime modifiedDate,
			string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4384b0e470421d75ae873058703c005a</Hash>
</Codenesium>*/
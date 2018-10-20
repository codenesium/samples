using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVStateProvinceCountryRegionRequestModel : AbstractApiRequestModel
	{
		public ApiVStateProvinceCountryRegionRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string countryRegionCode,
			string countryRegionName,
			bool isOnlyStateProvinceFlag,
			string stateProvinceCode,
			string stateProvinceName,
			int territoryID)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CountryRegionName = countryRegionName;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.StateProvinceCode = stateProvinceCode;
			this.StateProvinceName = stateProvinceName;
			this.TerritoryID = territoryID;
		}

		[Required]
		[JsonProperty]
		public string CountryRegionCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string CountryRegionName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsOnlyStateProvinceFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string StateProvinceCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string StateProvinceName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TerritoryID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>421bed33aaa2d7be04124a1ad5810314</Hash>
</Codenesium>*/
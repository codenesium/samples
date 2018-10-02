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
		public string CountryRegionCode { get; private set; }

		[Required]
		[JsonProperty]
		public string CountryRegionName { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[Required]
		[JsonProperty]
		public string StateProvinceCode { get; private set; }

		[Required]
		[JsonProperty]
		public string StateProvinceName { get; private set; }

		[Required]
		[JsonProperty]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b6fffd291b60a1f272e91b201f70e4d3</Hash>
</Codenesium>*/
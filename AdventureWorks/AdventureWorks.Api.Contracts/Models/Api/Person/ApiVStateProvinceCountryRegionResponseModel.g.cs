using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiVStateProvinceCountryRegionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int stateProvinceID,
			string countryRegionCode,
			string countryRegionName,
			bool isOnlyStateProvinceFlag,
			string stateProvinceCode,
			string stateProvinceName,
			int territoryID)
		{
			this.StateProvinceID = stateProvinceID;
			this.CountryRegionCode = countryRegionCode;
			this.CountryRegionName = countryRegionName;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.StateProvinceCode = stateProvinceCode;
			this.StateProvinceName = stateProvinceName;
			this.TerritoryID = territoryID;
		}

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public string CountryRegionName { get; private set; }

		[JsonProperty]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[JsonProperty]
		public string StateProvinceCode { get; private set; }

		[JsonProperty]
		public int StateProvinceID { get; private set; }

		[JsonProperty]
		public string StateProvinceName { get; private set; }

		[JsonProperty]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c96d5fe5846a9dd14ee79e2bfcbd6f87</Hash>
</Codenesium>*/
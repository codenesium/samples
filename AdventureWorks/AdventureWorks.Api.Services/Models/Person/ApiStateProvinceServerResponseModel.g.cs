using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiStateProvinceServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int stateProvinceID,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			string stateProvinceCode,
			int territoryID)
		{
			this.StateProvinceID = stateProvinceID;
			this.CountryRegionCode = countryRegionCode;
			this.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.StateProvinceCode = stateProvinceCode;
			this.TerritoryID = territoryID;
		}

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public string CountryRegionCodeEntity { get; private set; } = RouteConstants.CountryRegions;

		[JsonProperty]
		public ApiCountryRegionServerResponseModel CountryRegionCodeNavigation { get; private set; }

		public void SetCountryRegionCodeNavigation(ApiCountryRegionServerResponseModel value)
		{
			this.CountryRegionCodeNavigation = value;
		}

		[JsonProperty]
		public bool IsOnlyStateProvinceFlag { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public string StateProvinceCode { get; private set; }

		[JsonProperty]
		public int StateProvinceID { get; private set; }

		[JsonProperty]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e0682826aa9d95ee5cbd0e119b4f8c58</Hash>
</Codenesium>*/
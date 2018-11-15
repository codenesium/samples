using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiStateProvinceClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>d70edbda8f260fb9a3e922e409842675</Hash>
</Codenesium>*/
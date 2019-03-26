using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiStateProvinceClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiStateProvinceClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			string stateProvinceCode,
			int territoryID)
		{
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
		public bool IsOnlyStateProvinceFlag { get; private set; } = default(bool);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public string StateProvinceCode { get; private set; } = default(string);

		[JsonProperty]
		public int TerritoryID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>7ba961d8302868775390c72f7e6ec68d</Hash>
</Codenesium>*/
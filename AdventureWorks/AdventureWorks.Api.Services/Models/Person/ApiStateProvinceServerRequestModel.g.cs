using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiStateProvinceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiStateProvinceServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string CountryRegionCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsOnlyStateProvinceFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string StateProvinceCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int TerritoryID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>d379acbf141e18bb31cf90442bea4719</Hash>
</Codenesium>*/
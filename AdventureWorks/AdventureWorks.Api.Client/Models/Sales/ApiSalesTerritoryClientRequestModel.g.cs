using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesTerritoryClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSalesTerritoryClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD)
		{
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesYTD = salesYTD;
		}

		[JsonProperty]
		public decimal CostLastYear { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal CostYTD { get; private set; } = default(decimal);

		[JsonProperty]
		public string CountryRegionCode { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public decimal SalesLastYear { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal SalesYTD { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>cad360d3248726cbe086e8749dcede56</Hash>
</Codenesium>*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesTerritoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int territoryID,
			string @group,
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD)
		{
			this.TerritoryID = territoryID;
			this.@Group = @group;
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
		public decimal CostLastYear { get; private set; }

		[JsonProperty]
		public decimal CostYTD { get; private set; }

		[JsonProperty]
		public string CountryRegionCode { get; private set; }

		[JsonProperty]
		public string @Group { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public decimal SalesLastYear { get; private set; }

		[JsonProperty]
		public decimal SalesYTD { get; private set; }

		[JsonProperty]
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5c9f01c040b6d13d24b305d76c9b240e</Hash>
</Codenesium>*/
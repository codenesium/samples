using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSalesTerritoryServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int territoryID,
			decimal costLastYear,
			decimal costYTD,
			string countryRegionCode,
			DateTime modifiedDate,
			string name,
			string reservedGroup,
			Guid rowguid,
			decimal salesLastYear,
			decimal salesYTD)
		{
			this.TerritoryID = territoryID;
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReservedGroup = reservedGroup;
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
		public string ReservedGroup { get; private set; }

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
    <Hash>76aadd46c6f773894a22ac341e3852aa</Hash>
</Codenesium>*/
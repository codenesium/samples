using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesTerritory: AbstractDTO
	{
		public DTOSalesTerritory() : base()
		{}

		public void SetProperties(int territoryID,
		                          decimal costLastYear,
		                          decimal costYTD,
		                          string countryRegionCode,
		                          string @group,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          decimal salesLastYear,
		                          decimal salesYTD)
		{
			this.CostLastYear = costLastYear.ToDecimal();
			this.CostYTD = costYTD.ToDecimal();
			this.CountryRegionCode = countryRegionCode;
			this.@Group = @group;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesLastYear = salesLastYear.ToDecimal();
			this.SalesYTD = salesYTD.ToDecimal();
			this.TerritoryID = territoryID.ToInt();
		}

		public decimal CostLastYear { get; set; }
		public decimal CostYTD { get; set; }
		public string CountryRegionCode { get; set; }
		public string @Group { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public decimal SalesLastYear { get; set; }
		public decimal SalesYTD { get; set; }
		public int TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>992f694659c79d26b2a45700dbb9190f</Hash>
</Codenesium>*/
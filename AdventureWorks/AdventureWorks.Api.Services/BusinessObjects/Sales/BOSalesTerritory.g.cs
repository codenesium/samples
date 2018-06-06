using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSalesTerritory: AbstractBusinessObject
	{
		public BOSalesTerritory() : base()
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

		public decimal CostLastYear { get; private set; }
		public decimal CostYTD { get; private set; }
		public string CountryRegionCode { get; private set; }
		public string @Group { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public decimal SalesLastYear { get; private set; }
		public decimal SalesYTD { get; private set; }
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e332ade958c78ae720f45f670e8fd54a</Hash>
</Codenesium>*/
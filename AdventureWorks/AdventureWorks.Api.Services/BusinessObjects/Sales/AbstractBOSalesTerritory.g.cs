using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSalesTerritory : AbstractBusinessObject
	{
		public AbstractBOSalesTerritory()
			: base()
		{
		}

		public virtual void SetProperties(int territoryID,
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
			this.@Group = @group;
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesYTD = salesYTD;
			this.TerritoryID = territoryID;
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
    <Hash>7f02bd17f40105e5a05c6d2faf4d56a6</Hash>
</Codenesium>*/
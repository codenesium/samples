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
			this.CostLastYear = costLastYear;
			this.CostYTD = costYTD;
			this.CountryRegionCode = countryRegionCode;
			this.@Group = @group;
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
    <Hash>d784d7edc216cc438a67c2aef03ae438</Hash>
</Codenesium>*/
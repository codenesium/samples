using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSalesPerson : AbstractBusinessObject
	{
		public AbstractBOSalesPerson()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  decimal bonus,
		                                  decimal commissionPct,
		                                  DateTime modifiedDate,
		                                  Guid rowguid,
		                                  decimal salesLastYear,
		                                  decimal? salesQuota,
		                                  decimal salesYTD,
		                                  int? territoryID)
		{
			this.Bonus = bonus;
			this.BusinessEntityID = businessEntityID;
			this.CommissionPct = commissionPct;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesQuota = salesQuota;
			this.SalesYTD = salesYTD;
			this.TerritoryID = territoryID;
		}

		public decimal Bonus { get; private set; }

		public int BusinessEntityID { get; private set; }

		public decimal CommissionPct { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public Guid Rowguid { get; private set; }

		public decimal SalesLastYear { get; private set; }

		public decimal? SalesQuota { get; private set; }

		public decimal SalesYTD { get; private set; }

		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c4efcf8396b1b1ed6cdebf4b6dcf5805</Hash>
</Codenesium>*/
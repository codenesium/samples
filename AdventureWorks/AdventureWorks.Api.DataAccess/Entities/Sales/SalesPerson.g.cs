using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class SalesPerson : AbstractEntity
	{
		public SalesPerson()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			decimal bonus,
			decimal commissionPct,
			DateTime modifiedDate,
			Guid rowguid,
			decimal salesLastYear,
			decimal? salesQuota,
			decimal salesYTD,
			int? territoryID)
		{
			this.BusinessEntityID = businessEntityID;
			this.Bonus = bonus;
			this.CommissionPct = commissionPct;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.SalesLastYear = salesLastYear;
			this.SalesQuota = salesQuota;
			this.SalesYTD = salesYTD;
			this.TerritoryID = territoryID;
		}

		[Column("Bonus")]
		public virtual decimal Bonus { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("CommissionPct")]
		public virtual decimal CommissionPct { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SalesLastYear")]
		public virtual decimal SalesLastYear { get; private set; }

		[Column("SalesQuota")]
		public virtual decimal? SalesQuota { get; private set; }

		[Column("SalesYTD")]
		public virtual decimal SalesYTD { get; private set; }

		[Column("TerritoryID")]
		public virtual int? TerritoryID { get; private set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(SalesTerritory item)
		{
			this.TerritoryIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>96216cdfddcb2437c34e2d6c1d2b53a5</Hash>
</Codenesium>*/
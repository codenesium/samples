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
			decimal bonus,
			int businessEntityID,
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
		public virtual SalesTerritory SalesTerritoryNavigation { get; private set; }

		public void SetSalesTerritoryNavigation(SalesTerritory item)
		{
			this.SalesTerritoryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>1b39673adbafb240a9eb427cf99487c9</Hash>
</Codenesium>*/
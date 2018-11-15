using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTerritoryHistory", Schema="Sales")]
	public partial class SalesTerritoryHistory : AbstractEntity
	{
		public SalesTerritoryHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			DateTime? endDate,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			int territoryID)
		{
			this.BusinessEntityID = businessEntityID;
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.StartDate = startDate;
			this.TerritoryID = territoryID;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("EndDate")]
		public virtual DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[Key]
		[Column("TerritoryID")]
		public virtual int TerritoryID { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPersonNavigation { get; private set; }

		public void SetSalesPersonNavigation(SalesPerson item)
		{
			this.SalesPersonNavigation = item;
		}

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritoryNavigation { get; private set; }

		public void SetSalesTerritoryNavigation(SalesTerritory item)
		{
			this.SalesTerritoryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>5a8c949ea74f8c244a32c7b14fb80567</Hash>
</Codenesium>*/
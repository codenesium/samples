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
		public virtual SalesPerson BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(SalesPerson item)
		{
			this.BusinessEntityIDNavigation = item;
		}

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(SalesTerritory item)
		{
			this.TerritoryIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e938bc77fc0047405bbd8310ebb80ce5</Hash>
</Codenesium>*/
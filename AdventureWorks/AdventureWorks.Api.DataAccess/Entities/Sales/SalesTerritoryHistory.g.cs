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
		public int BusinessEntityID { get; private set; }

		[Column("EndDate")]
		public DateTime? EndDate { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Key]
		[Column("StartDate")]
		public DateTime StartDate { get; private set; }

		[Key]
		[Column("TerritoryID")]
		public int TerritoryID { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPersonNavigation { get; private set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritoryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dd1b8a33fc9c22540bbbd5dace1bffaf</Hash>
</Codenesium>*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesTerritoryHistory", Schema="Sales")]
	public partial class SalesTerritoryHistory: AbstractEntityFrameworkPOCO
	{
		public SalesTerritoryHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			int territoryID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.StartDate = startDate.ToDateTime();
			this.TerritoryID = territoryID.ToInt();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPerson { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>aa4ea3f92de321c5c5f6a36b4d114545</Hash>
</Codenesium>*/
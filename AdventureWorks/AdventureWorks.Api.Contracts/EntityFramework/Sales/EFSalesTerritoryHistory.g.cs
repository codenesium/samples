using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritoryHistory", Schema="Sales")]
	public partial class EFSalesTerritoryHistory
	{
		public EFSalesTerritoryHistory()
		{}

		public void SetProperties(int businessEntityID,
		                          int territoryID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.TerritoryID = territoryID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToNullableDateTime();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("TerritoryID", TypeName="int")]
		public int TerritoryID {get; set;}

		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}

		[Column("EndDate", TypeName="datetime")]
		public Nullable<DateTime> EndDate {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFSalesPerson SalesPerson { get; set; }

		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>d51f0da54fe436a1105a46c541ee7dfe</Hash>
</Codenesium>*/
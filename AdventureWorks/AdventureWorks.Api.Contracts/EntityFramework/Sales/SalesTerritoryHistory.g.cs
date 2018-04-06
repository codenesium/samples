using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesTerritoryHistory", Schema="Sales")]
	public partial class EFSalesTerritoryHistory
	{
		public EFSalesTerritoryHistory()
		{}

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

		[ForeignKey("BusinessEntityID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>1628b82cc264fde8f08b164f77b0d5f2</Hash>
</Codenesium>*/
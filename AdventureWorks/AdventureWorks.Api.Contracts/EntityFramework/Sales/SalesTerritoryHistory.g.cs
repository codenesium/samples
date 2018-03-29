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
		public int BusinessEntityID {get; set;}
		public int TerritoryID {get; set;}
		public DateTime StartDate {get; set;}
		public Nullable<DateTime> EndDate {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b43c54cf9e023064f38ed064df9a9d41</Hash>
</Codenesium>*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPerson", Schema="Sales")]
	public partial class EFSalesPerson
	{
		public EFSalesPerson()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public Nullable<int> TerritoryID {get; set;}
		public Nullable<decimal> SalesQuota {get; set;}
		public decimal Bonus {get; set;}
		public decimal CommissionPct {get; set;}
		public decimal SalesYTD {get; set;}
		public decimal SalesLastYear {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>347d44fbc810417fdace4dcb82e46835</Hash>
</Codenesium>*/
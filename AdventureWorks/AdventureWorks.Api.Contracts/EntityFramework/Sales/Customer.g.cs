using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Customer", Schema="Sales")]
	public partial class EFCustomer
	{
		public EFCustomer()
		{}

		[Key]
		public int CustomerID {get; set;}
		public Nullable<int> PersonID {get; set;}
		public Nullable<int> StoreID {get; set;}
		public Nullable<int> TerritoryID {get; set;}
		public string AccountNumber {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("PersonID")]
		public virtual EFPerson PersonRef { get; set; }
		[ForeignKey("StoreID")]
		public virtual EFStore StoreRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b8b3b71ea2af12d1ff684681805d1801</Hash>
</Codenesium>*/
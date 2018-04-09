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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CustomerID", TypeName="int")]
		public int CustomerID {get; set;}

		[Column("PersonID", TypeName="int")]
		public Nullable<int> PersonID {get; set;}

		[Column("StoreID", TypeName="int")]
		public Nullable<int> StoreID {get; set;}

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID {get; set;}

		[Column("AccountNumber", TypeName="varchar(10)")]
		public string AccountNumber {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }

		public virtual EFStore Store { get; set; }

		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>77eedf9fad0716bf30c86d89de9a673e</Hash>
</Codenesium>*/
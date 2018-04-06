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

		[ForeignKey("PersonID")]
		public virtual EFPerson PersonRef { get; set; }
		[ForeignKey("StoreID")]
		public virtual EFStore StoreRef { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>a8e9a5fbb6b128ecde1fe085b2cafa0c</Hash>
</Codenesium>*/
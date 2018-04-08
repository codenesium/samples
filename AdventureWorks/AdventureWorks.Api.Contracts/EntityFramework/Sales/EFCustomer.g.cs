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
		public virtual EFPerson Person { get; set; }
		[ForeignKey("StoreID")]
		public virtual EFStore Store { get; set; }
		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>a1b0241f32d6e79c7e28c178e33d4d3c</Hash>
</Codenesium>*/
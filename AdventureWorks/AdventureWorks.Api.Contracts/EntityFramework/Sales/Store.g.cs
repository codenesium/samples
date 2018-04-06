using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Store", Schema="Sales")]
	public partial class EFStore
	{
		public EFStore()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID {get; set;}
		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
		[ForeignKey("SalesPersonID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>82e5b5207af9305b5f5662619264fa9a</Hash>
</Codenesium>*/
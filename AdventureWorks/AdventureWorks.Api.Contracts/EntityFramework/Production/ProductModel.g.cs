using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModel", Schema="Production")]
	public partial class EFProductModel
	{
		public EFProductModel()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductModelID", TypeName="int")]
		public int ProductModelID {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("CatalogDescription", TypeName="xml(-1)")]
		public string CatalogDescription {get; set;}
		[Column("Instructions", TypeName="xml(-1)")]
		public string Instructions {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>81357feca992fddf3cf3ceaf4681620d</Hash>
</Codenesium>*/
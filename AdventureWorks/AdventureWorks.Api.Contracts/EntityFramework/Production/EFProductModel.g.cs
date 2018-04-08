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
    <Hash>92d7189c0678e4c3990d2accf2b50fb5</Hash>
</Codenesium>*/
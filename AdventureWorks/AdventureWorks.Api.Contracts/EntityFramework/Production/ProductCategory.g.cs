using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductCategory", Schema="Production")]
	public partial class EFProductCategory
	{
		public EFProductCategory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>f460231d7589f0a53acc870767dea2aa</Hash>
</Codenesium>*/
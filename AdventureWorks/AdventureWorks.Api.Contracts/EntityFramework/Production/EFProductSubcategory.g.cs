using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductSubcategory", Schema="Production")]
	public partial class EFProductSubcategory
	{
		public EFProductSubcategory()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductSubcategoryID", TypeName="int")]
		public int ProductSubcategoryID {get; set;}

		[Column("ProductCategoryID", TypeName="int")]
		public int ProductCategoryID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductCategoryID")]
		public virtual EFProductCategory ProductCategory { get; set; }
	}
}

/*<Codenesium>
    <Hash>ece9a5aaf3e178b97c3780d3849c9736</Hash>
</Codenesium>*/
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
		public virtual EFProductCategory ProductCategoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>d5e857efa4d4f0df9d18efd723da645e</Hash>
</Codenesium>*/
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
		public int ProductSubcategoryID {get; set;}
		public int ProductCategoryID {get; set;}
		public string Name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductCategoryID")]
		public virtual EFProductCategory ProductCategoryRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b8dbd194f7817a22441ca4b98a44891d</Hash>
</Codenesium>*/
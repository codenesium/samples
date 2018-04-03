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
		public int productSubcategoryID {get; set;}
		public int productCategoryID {get; set;}
		public string name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>72b20b27ab90a45bd3266eaa9dbe0f21</Hash>
</Codenesium>*/
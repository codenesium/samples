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
		public int productCategoryID {get; set;}
		public string name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>a2763da2bc859224dd7a0e445487a992</Hash>
</Codenesium>*/
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
		public int ProductCategoryID {get; set;}
		public string Name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>6eda8b77b462d29df6db4761498d160b</Hash>
</Codenesium>*/
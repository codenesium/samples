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
		public int ProductModelID {get; set;}
		public string Name {get; set;}
		public string CatalogDescription {get; set;}
		public string Instructions {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>52d3fd967cbb19981f3edc1deca232d5</Hash>
</Codenesium>*/
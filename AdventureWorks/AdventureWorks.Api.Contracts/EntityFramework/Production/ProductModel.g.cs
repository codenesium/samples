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
		public int productModelID {get; set;}
		public string name {get; set;}
		public string catalogDescription {get; set;}
		public string instructions {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>c627b77765a88b109bb6565e0e62edef</Hash>
</Codenesium>*/
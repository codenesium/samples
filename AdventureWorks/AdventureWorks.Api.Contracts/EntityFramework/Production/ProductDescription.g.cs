using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductDescription", Schema="Production")]
	public partial class EFProductDescription
	{
		public EFProductDescription()
		{}

		[Key]
		public int productDescriptionID {get; set;}
		public string description {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>08768e1bd819dd13b7c8bdc6287d33c1</Hash>
</Codenesium>*/
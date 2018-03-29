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
		public int ProductDescriptionID {get; set;}
		public string Description {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d89c3aa548e8e881b098ca184013f9d5</Hash>
</Codenesium>*/
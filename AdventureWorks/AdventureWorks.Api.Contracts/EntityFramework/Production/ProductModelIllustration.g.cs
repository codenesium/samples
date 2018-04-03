using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class EFProductModelIllustration
	{
		public EFProductModelIllustration()
		{}

		[Key]
		public int productModelID {get; set;}
		public int illustrationID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>39402c4687926b5ab160cefe307d85a0</Hash>
</Codenesium>*/
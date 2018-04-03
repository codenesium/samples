using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class EFSpecialOfferProduct
	{
		public EFSpecialOfferProduct()
		{}

		[Key]
		public int specialOfferID {get; set;}
		public int productID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>6c2fd9c744d4f907bd627c82d955c863</Hash>
</Codenesium>*/
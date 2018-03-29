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
		public int SpecialOfferID {get; set;}
		public int ProductID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("SpecialOfferID")]
		public virtual EFSpecialOffer SpecialOfferRef { get; set; }
		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>29a81fb2b9bbd95a56c1c1e8b4a28fcd</Hash>
</Codenesium>*/
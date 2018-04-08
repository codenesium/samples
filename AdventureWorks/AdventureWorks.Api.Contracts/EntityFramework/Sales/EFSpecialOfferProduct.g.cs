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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("SpecialOfferID")]
		public virtual EFSpecialOffer SpecialOffer { get; set; }
		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>64f6d8e0012d895a3567012329fd8ee3</Hash>
</Codenesium>*/
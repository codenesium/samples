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
		public virtual EFSpecialOffer SpecialOfferRef { get; set; }
		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b5414930a8a10c3db89103ccf7865916</Hash>
</Codenesium>*/
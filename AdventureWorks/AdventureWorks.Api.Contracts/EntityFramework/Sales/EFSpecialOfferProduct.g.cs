using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class EFSpecialOfferProduct
	{
		public EFSpecialOfferProduct()
		{}

		public void SetProperties(int specialOfferID,
		                          int productID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.SpecialOfferID = specialOfferID.ToInt();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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

		public virtual EFSpecialOffer SpecialOffer { get; set; }

		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>43311acc254f2162ef6c3ac7b1482868</Hash>
</Codenesium>*/
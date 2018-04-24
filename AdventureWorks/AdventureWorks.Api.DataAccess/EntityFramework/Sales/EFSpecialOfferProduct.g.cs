using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class EFSpecialOfferProduct: AbstractEntityFrameworkPOCO
	{
		public EFSpecialOfferProduct()
		{}

		public void SetProperties(
			int specialOfferID,
			int productID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.SpecialOfferID = specialOfferID.ToInt();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("SpecialOfferID")]
		public virtual EFSpecialOffer SpecialOffer { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>a14cc7c23425f348cbf11a5581fb03d0</Hash>
</Codenesium>*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class SpecialOfferProduct: AbstractEntityFrameworkDTO
	{
		public SpecialOfferProduct()
		{}

		public void SetProperties(
			int specialOfferID,
			DateTime modifiedDate,
			int productID,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SpecialOfferID = specialOfferID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Key]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; set; }

		[ForeignKey("SpecialOfferID")]
		public virtual SpecialOffer SpecialOffer { get; set; }
	}
}

/*<Codenesium>
    <Hash>0391bc4073e1dd9b62c095cff788f7a2</Hash>
</Codenesium>*/
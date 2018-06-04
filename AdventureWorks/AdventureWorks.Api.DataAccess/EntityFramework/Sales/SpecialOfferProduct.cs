using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class SpecialOfferProduct: AbstractEntity
	{
		public SpecialOfferProduct()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			int productID,
			Guid rowguid,
			int specialOfferID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.SpecialOfferID = specialOfferID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Key]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID { get; private set; }

		[ForeignKey("SpecialOfferID")]
		public virtual SpecialOffer SpecialOffer { get; set; }
	}
}

/*<Codenesium>
    <Hash>9e16218edea6c34ff452a03f9fef45a5</Hash>
</Codenesium>*/
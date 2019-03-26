using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOfferProduct", Schema="Sales")]
	public partial class SpecialOfferProduct : AbstractEntity
	{
		public SpecialOfferProduct()
		{
		}

		public virtual void SetProperties(
			int specialOfferID,
			DateTime modifiedDate,
			int productID,
			Guid rowguid)
		{
			this.SpecialOfferID = specialOfferID;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Rowguid = rowguid;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("SpecialOfferID")]
		public virtual int SpecialOfferID { get; private set; }

		[ForeignKey("SpecialOfferID")]
		public virtual SpecialOffer SpecialOfferIDNavigation { get; private set; }

		public void SetSpecialOfferIDNavigation(SpecialOffer item)
		{
			this.SpecialOfferIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>997f50c4859e1544d5341ce031d843d4</Hash>
</Codenesium>*/
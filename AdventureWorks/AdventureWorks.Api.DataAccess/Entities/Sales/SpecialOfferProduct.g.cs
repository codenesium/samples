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
		public virtual SpecialOffer SpecialOfferNavigation { get; private set; }

		public void SetSpecialOfferNavigation(SpecialOffer item)
		{
			this.SpecialOfferNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>3b89da1f68e85d1fc0ac5de4423e8749</Hash>
</Codenesium>*/
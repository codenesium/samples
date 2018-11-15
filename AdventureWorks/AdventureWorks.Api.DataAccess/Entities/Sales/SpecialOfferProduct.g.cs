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
			DateTime modifiedDate,
			int productID,
			Guid rowguid,
			int specialOfferID)
		{
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Rowguid = rowguid;
			this.SpecialOfferID = specialOfferID;
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
    <Hash>061df3d3f571a4b77ebc7d77ee86b941</Hash>
</Codenesium>*/
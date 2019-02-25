using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductModelIllustration", Schema="Production")]
	public partial class ProductModelIllustration : AbstractEntity
	{
		public ProductModelIllustration()
		{
		}

		public virtual void SetProperties(
			int productModelID,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID;
			this.IllustrationID = illustrationID;
			this.ModifiedDate = modifiedDate;
		}

		[Key]
		[Column("IllustrationID")]
		public virtual int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }

		[ForeignKey("IllustrationID")]
		public virtual Illustration IllustrationIDNavigation { get; private set; }

		public void SetIllustrationIDNavigation(Illustration item)
		{
			this.IllustrationIDNavigation = item;
		}

		[ForeignKey("ProductModelID")]
		public virtual ProductModel ProductModelIDNavigation { get; private set; }

		public void SetProductModelIDNavigation(ProductModel item)
		{
			this.ProductModelIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>38c83897587ef46cc638dab270e07d2d</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class ProductProductPhoto : AbstractEntity
	{
		public ProductProductPhoto()
		{
		}

		public virtual void SetProperties(
			int productID,
			DateTime modifiedDate,
			bool primary,
			int productPhotoID)
		{
			this.ProductID = productID;
			this.ModifiedDate = modifiedDate;
			this.Primary = primary;
			this.ProductPhotoID = productPhotoID;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("Primary")]
		public virtual bool Primary { get; private set; }

		[Key]
		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Key]
		[Column("ProductPhotoID")]
		public virtual int ProductPhotoID { get; private set; }

		[ForeignKey("ProductID")]
		public virtual Product ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(Product item)
		{
			this.ProductIDNavigation = item;
		}

		[ForeignKey("ProductPhotoID")]
		public virtual ProductPhoto ProductPhotoIDNavigation { get; private set; }

		public void SetProductPhotoIDNavigation(ProductPhoto item)
		{
			this.ProductPhotoIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>78d7e2c90d50de003512f6d9c9aa6ebc</Hash>
</Codenesium>*/
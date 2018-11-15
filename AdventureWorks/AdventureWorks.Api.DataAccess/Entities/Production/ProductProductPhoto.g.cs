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
			DateTime modifiedDate,
			bool primary,
			int productID,
			int productPhotoID)
		{
			this.ModifiedDate = modifiedDate;
			this.Primary = primary;
			this.ProductID = productID;
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
	}
}

/*<Codenesium>
    <Hash>ee52a82bf9a1f5f35d71ddc7810e2fbb</Hash>
</Codenesium>*/
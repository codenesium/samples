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
		public DateTime ModifiedDate { get; private set; }

		[Column("Primary")]
		public bool Primary { get; private set; }

		[Key]
		[Column("ProductID")]
		public int ProductID { get; private set; }

		[Column("ProductPhotoID")]
		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8dff4266afe8ed9676197517c5d20e6c</Hash>
</Codenesium>*/
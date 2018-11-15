using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class ProductPhoto : AbstractEntity
	{
		public ProductPhoto()
		{
		}

		public virtual void SetProperties(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate;
			this.ProductPhotoID = productPhotoID;
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		[Column("LargePhoto")]
		public virtual byte[] LargePhoto { get; private set; }

		[MaxLength(50)]
		[Column("LargePhotoFileName")]
		public virtual string LargePhotoFileName { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductPhotoID")]
		public virtual int ProductPhotoID { get; private set; }

		[Column("ThumbNailPhoto")]
		public virtual byte[] ThumbNailPhoto { get; private set; }

		[MaxLength(50)]
		[Column("ThumbnailPhotoFileName")]
		public virtual string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>43f4aeaea054b976eb71eb1b32e8162b</Hash>
</Codenesium>*/
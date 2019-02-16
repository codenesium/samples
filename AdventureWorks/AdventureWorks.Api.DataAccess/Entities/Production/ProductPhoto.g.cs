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
			int productPhotoID,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.ProductPhotoID = productPhotoID;
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate;
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
    <Hash>4b075fe374bec60c400fe1aa2c2b03b4</Hash>
</Codenesium>*/
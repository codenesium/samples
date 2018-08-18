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
		public byte[] LargePhoto { get; private set; }

		[MaxLength(50)]
		[Column("LargePhotoFileName")]
		public string LargePhotoFileName { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductPhotoID")]
		public int ProductPhotoID { get; private set; }

		[Column("ThumbNailPhoto")]
		public byte[] ThumbNailPhoto { get; private set; }

		[MaxLength(50)]
		[Column("ThumbnailPhotoFileName")]
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6aa5933a914ad133ef0a81cf42188f3d</Hash>
</Codenesium>*/
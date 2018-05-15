using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class ProductPhoto: AbstractEntityFrameworkPOCO
	{
		public ProductPhoto()
		{}

		public void SetProperties(
			int productPhotoID,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductPhotoID = productPhotoID.ToInt();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		[Column("LargePhoto", TypeName="varbinary(-1)")]
		public byte[] LargePhoto { get; set; }

		[Column("LargePhotoFileName", TypeName="nvarchar(50)")]
		public string LargePhotoFileName { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; set; }

		[Column("ThumbNailPhoto", TypeName="varbinary(-1)")]
		public byte[] ThumbNailPhoto { get; set; }

		[Column("ThumbnailPhotoFileName", TypeName="nvarchar(50)")]
		public string ThumbnailPhotoFileName { get; set; }
	}
}

/*<Codenesium>
    <Hash>065a89371f8927a69523bcbd443f564b</Hash>
</Codenesium>*/
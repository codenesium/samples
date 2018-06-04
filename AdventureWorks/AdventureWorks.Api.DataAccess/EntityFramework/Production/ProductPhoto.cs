using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class ProductPhoto: AbstractEntity
	{
		public ProductPhoto()
		{}

		public void SetProperties(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			int productPhotoID,
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
		public byte[] LargePhoto { get; private set; }

		[Column("LargePhotoFileName", TypeName="nvarchar(50)")]
		public string LargePhotoFileName { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; private set; }

		[Column("ThumbNailPhoto", TypeName="varbinary(-1)")]
		public byte[] ThumbNailPhoto { get; private set; }

		[Column("ThumbnailPhotoFileName", TypeName="nvarchar(50)")]
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f0078ca8ba60abebcc65197a6324779</Hash>
</Codenesium>*/
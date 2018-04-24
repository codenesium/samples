using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class EFProductPhoto: AbstractEntityFrameworkPOCO
	{
		public EFProductPhoto()
		{}

		public void SetProperties(
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate)
		{
			this.ProductPhotoID = productPhotoID.ToInt();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName.ToString();
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID { get; set; }

		[Column("ThumbNailPhoto", TypeName="varbinary(-1)")]
		public byte[] ThumbNailPhoto { get; set; }

		[Column("ThumbnailPhotoFileName", TypeName="nvarchar(50)")]
		public string ThumbnailPhotoFileName { get; set; }

		[Column("LargePhoto", TypeName="varbinary(-1)")]
		public byte[] LargePhoto { get; set; }

		[Column("LargePhotoFileName", TypeName="nvarchar(50)")]
		public string LargePhotoFileName { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>a4d1df2e5a0cddb4690b164ad4cd720f</Hash>
</Codenesium>*/
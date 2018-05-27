using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductPhoto: AbstractDTO
	{
		public DTOProductPhoto() : base()
		{}

		public void SetProperties(int productPhotoID,
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

		public byte[] LargePhoto { get; set; }
		public string LargePhotoFileName { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductPhotoID { get; set; }
		public byte[] ThumbNailPhoto { get; set; }
		public string ThumbnailPhotoFileName { get; set; }
	}
}

/*<Codenesium>
    <Hash>5ae655d9d86a774ae573d6e5d86180b3</Hash>
</Codenesium>*/
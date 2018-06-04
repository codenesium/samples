using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductPhoto: AbstractBusinessObject
	{
		public BOProductPhoto() : base()
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

		public byte[] LargePhoto { get; private set; }
		public string LargePhotoFileName { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductPhotoID { get; private set; }
		public byte[] ThumbNailPhoto { get; private set; }
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ccfd9c02cc2771901c87199625f462d9</Hash>
</Codenesium>*/
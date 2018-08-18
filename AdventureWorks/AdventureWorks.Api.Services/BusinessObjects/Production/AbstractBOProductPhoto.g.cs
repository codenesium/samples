using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductPhoto : AbstractBusinessObject
	{
		public AbstractBOProductPhoto()
			: base()
		{
		}

		public virtual void SetProperties(int productPhotoID,
		                                  byte[] largePhoto,
		                                  string largePhotoFileName,
		                                  DateTime modifiedDate,
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

		public byte[] LargePhoto { get; private set; }

		public string LargePhotoFileName { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int ProductPhotoID { get; private set; }

		public byte[] ThumbNailPhoto { get; private set; }

		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>54d9e80f4cb082aa0ee6b4ef2f2fe442</Hash>
</Codenesium>*/
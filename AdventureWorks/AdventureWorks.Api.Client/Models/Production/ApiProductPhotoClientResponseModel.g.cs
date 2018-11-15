using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductPhotoClientResponseModel : AbstractApiClientResponseModel
	{
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

		[JsonProperty]
		public byte[] LargePhoto { get; private set; }

		[JsonProperty]
		public string LargePhotoFileName { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductPhotoID { get; private set; }

		[JsonProperty]
		public byte[] ThumbNailPhoto { get; private set; }

		[JsonProperty]
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5426593e9fe34874c9592c6b643550d3</Hash>
</Codenesium>*/
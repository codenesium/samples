using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductPhotoServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public byte[] LargePhoto { get; private set; }

		[Required]
		[JsonProperty]
		public string LargePhotoFileName { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductPhotoID { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] ThumbNailPhoto { get; private set; }

		[Required]
		[JsonProperty]
		public string ThumbnailPhotoFileName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>98db8531cc05c6866870c0e7182e4e45</Hash>
</Codenesium>*/
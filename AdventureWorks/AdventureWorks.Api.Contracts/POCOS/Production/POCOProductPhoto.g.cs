using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductPhoto
	{
		public POCOProductPhoto()
		{}

		public POCOProductPhoto(
			int productPhotoID,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate)
		{
			this.ProductPhotoID = productPhotoID.ToInt();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductPhotoID { get; set; }
		public byte[] ThumbNailPhoto { get; set; }
		public string ThumbnailPhotoFileName { get; set; }
		public byte[] LargePhoto { get; set; }
		public string LargePhotoFileName { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoIDValue { get; set; } = true;

		public bool ShouldSerializeProductPhotoID()
		{
			return this.ShouldSerializeProductPhotoIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbNailPhotoValue { get; set; } = true;

		public bool ShouldSerializeThumbNailPhoto()
		{
			return this.ShouldSerializeThumbNailPhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbnailPhotoFileNameValue { get; set; } = true;

		public bool ShouldSerializeThumbnailPhotoFileName()
		{
			return this.ShouldSerializeThumbnailPhotoFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoValue { get; set; } = true;

		public bool ShouldSerializeLargePhoto()
		{
			return this.ShouldSerializeLargePhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoFileNameValue { get; set; } = true;

		public bool ShouldSerializeLargePhotoFileName()
		{
			return this.ShouldSerializeLargePhotoFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductPhotoIDValue = false;
			this.ShouldSerializeThumbNailPhotoValue = false;
			this.ShouldSerializeThumbnailPhotoFileNameValue = false;
			this.ShouldSerializeLargePhotoValue = false;
			this.ShouldSerializeLargePhotoFileNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>58efe32c42d4d5876dbca34477053a77</Hash>
</Codenesium>*/
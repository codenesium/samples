using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductPhoto
	{
		public POCOProductPhoto()
		{}

		public POCOProductPhoto(int productPhotoID,
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

		public int ProductPhotoID {get; set;}
		public byte[] ThumbNailPhoto {get; set;}
		public string ThumbnailPhotoFileName {get; set;}
		public byte[] LargePhoto {get; set;}
		public string LargePhotoFileName {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductPhotoIDValue {get; set;} = true;

		public bool ShouldSerializeProductPhotoID()
		{
			return ShouldSerializeProductPhotoIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbNailPhotoValue {get; set;} = true;

		public bool ShouldSerializeThumbNailPhoto()
		{
			return ShouldSerializeThumbNailPhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeThumbnailPhotoFileNameValue {get; set;} = true;

		public bool ShouldSerializeThumbnailPhotoFileName()
		{
			return ShouldSerializeThumbnailPhotoFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoValue {get; set;} = true;

		public bool ShouldSerializeLargePhoto()
		{
			return ShouldSerializeLargePhotoValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLargePhotoFileNameValue {get; set;} = true;

		public bool ShouldSerializeLargePhotoFileName()
		{
			return ShouldSerializeLargePhotoFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>a5fd55bc247329eee5d692f8a1b9adc4</Hash>
</Codenesium>*/
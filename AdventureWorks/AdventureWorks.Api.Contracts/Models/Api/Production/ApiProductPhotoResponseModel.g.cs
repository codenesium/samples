using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductPhotoResponseModel: AbstractApiResponseModel
	{
		public ApiProductPhotoResponseModel() : base()
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

		public byte[] LargePhoto { get; private set; }
		public string LargePhotoFileName { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductPhotoID { get; private set; }
		public byte[] ThumbNailPhoto { get; private set; }
		public string ThumbnailPhotoFileName { get; private set; }

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

		public void DisableAllFields()
		{
			this.ShouldSerializeLargePhotoValue = false;
			this.ShouldSerializeLargePhotoFileNameValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductPhotoIDValue = false;
			this.ShouldSerializeThumbNailPhotoValue = false;
			this.ShouldSerializeThumbnailPhotoFileNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>364c7a62bcb3d98b34b68a71b8d14781</Hash>
</Codenesium>*/
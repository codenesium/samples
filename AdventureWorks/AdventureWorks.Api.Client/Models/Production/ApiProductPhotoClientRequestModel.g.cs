using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductPhotoClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductPhotoClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate;
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		[JsonProperty]
		public byte[] LargePhoto { get; private set; } = default(byte[]);

		[JsonProperty]
		public string LargePhotoFileName { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public byte[] ThumbNailPhoto { get; private set; } = default(byte[]);

		[JsonProperty]
		public string ThumbnailPhotoFileName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>982877afaafe9222f5e58bff1b3ebdf2</Hash>
</Codenesium>*/
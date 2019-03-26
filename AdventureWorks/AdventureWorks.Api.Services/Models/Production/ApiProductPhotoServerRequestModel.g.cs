using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductPhotoServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductPhotoServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public byte[] ThumbNailPhoto { get; private set; } = default(byte[]);

		[JsonProperty]
		public string ThumbnailPhotoFileName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>fbb79078a7ae9c8d95f4fffd86777ba2</Hash>
</Codenesium>*/
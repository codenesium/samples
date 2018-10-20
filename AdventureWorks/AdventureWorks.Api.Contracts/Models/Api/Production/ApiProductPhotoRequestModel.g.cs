using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductPhotoRequestModel : AbstractApiRequestModel
	{
		public ApiProductPhotoRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public byte[] ThumbNailPhoto { get; private set; } = default(byte[]);

		[JsonProperty]
		public string ThumbnailPhotoFileName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c3dd253161492c24a2785ddfe3c316de</Hash>
</Codenesium>*/
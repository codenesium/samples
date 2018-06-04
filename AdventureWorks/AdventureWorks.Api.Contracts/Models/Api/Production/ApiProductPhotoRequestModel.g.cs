using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductPhotoRequestModel: AbstractApiRequestModel
	{
		public ApiProductPhotoRequestModel() : base()
		{}

		public void SetProperties(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
		}

		private byte[] largePhoto;

		public byte[] LargePhoto
		{
			get
			{
				return this.largePhoto.IsEmptyOrZeroOrNull() ? null : this.largePhoto;
			}

			set
			{
				this.largePhoto = value;
			}
		}

		private string largePhotoFileName;

		public string LargePhotoFileName
		{
			get
			{
				return this.largePhotoFileName.IsEmptyOrZeroOrNull() ? null : this.largePhotoFileName;
			}

			set
			{
				this.largePhotoFileName = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private byte[] thumbNailPhoto;

		public byte[] ThumbNailPhoto
		{
			get
			{
				return this.thumbNailPhoto.IsEmptyOrZeroOrNull() ? null : this.thumbNailPhoto;
			}

			set
			{
				this.thumbNailPhoto = value;
			}
		}

		private string thumbnailPhotoFileName;

		public string ThumbnailPhotoFileName
		{
			get
			{
				return this.thumbnailPhotoFileName.IsEmptyOrZeroOrNull() ? null : this.thumbnailPhotoFileName;
			}

			set
			{
				this.thumbnailPhotoFileName = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4b6021475c5f2722496f9b821c438fbe</Hash>
</Codenesium>*/
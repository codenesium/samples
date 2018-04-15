using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductPhotoModel
	{
		public ProductPhotoModel()
		{}

		public ProductPhotoModel(
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName,
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate)
		{
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName.ToString();
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>11b53448184ef904de1e37f6f75b0495</Hash>
</Codenesium>*/
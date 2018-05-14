using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductPhotoModel
	{
		public ApiProductPhotoModel()
		{}

		public ApiProductPhotoModel(
			byte[] largePhoto,
			string largePhotoFileName,
			DateTime modifiedDate,
			byte[] thumbNailPhoto,
			string thumbnailPhotoFileName)
		{
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName.ToString();
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
    <Hash>52abac710cb74b41b2a94094f2fc66f9</Hash>
</Codenesium>*/
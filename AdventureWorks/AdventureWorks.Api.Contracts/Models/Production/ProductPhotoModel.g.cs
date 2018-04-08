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
		public ProductPhotoModel(byte[] thumbNailPhoto,
		                         string thumbnailPhotoFileName,
		                         byte[] largePhoto,
		                         string largePhotoFileName,
		                         DateTime modifiedDate)
		{
			this.ThumbNailPhoto = thumbNailPhoto;
			this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
			this.LargePhoto = largePhoto;
			this.LargePhotoFileName = largePhotoFileName;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private byte[] _thumbNailPhoto;
		public byte[] ThumbNailPhoto
		{
			get
			{
				return _thumbNailPhoto.IsEmptyOrZeroOrNull() ? null : _thumbNailPhoto;
			}
			set
			{
				this._thumbNailPhoto = value;
			}
		}

		private string _thumbnailPhotoFileName;
		public string ThumbnailPhotoFileName
		{
			get
			{
				return _thumbnailPhotoFileName.IsEmptyOrZeroOrNull() ? null : _thumbnailPhotoFileName;
			}
			set
			{
				this._thumbnailPhotoFileName = value;
			}
		}

		private byte[] _largePhoto;
		public byte[] LargePhoto
		{
			get
			{
				return _largePhoto.IsEmptyOrZeroOrNull() ? null : _largePhoto;
			}
			set
			{
				this._largePhoto = value;
			}
		}

		private string _largePhotoFileName;
		public string LargePhotoFileName
		{
			get
			{
				return _largePhotoFileName.IsEmptyOrZeroOrNull() ? null : _largePhotoFileName;
			}
			set
			{
				this._largePhotoFileName = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>90fc86dc9049cc09c03ba2f19f975ab3</Hash>
</Codenesium>*/
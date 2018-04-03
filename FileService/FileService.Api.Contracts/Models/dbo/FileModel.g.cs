using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class FileModel
	{
		public FileModel()
		{}
		public FileModel(Guid externalId,
		                 string privateKey,
		                 string publicKey,
		                 string location,
		                 DateTime expiration,
		                 string extension,
		                 DateTime dateCreated,
		                 decimal fileSizeInBytes,
		                 int fileTypeId,
		                 Nullable<int> bucketId,
		                 string description)
		{
			this.ExternalId = externalId;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
			this.Location = location;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.DateCreated = dateCreated.ToDateTime();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.FileTypeId = fileTypeId.ToInt();
			this.BucketId = bucketId.ToNullableInt();
			this.Description = description;
		}

		private Guid _externalId;
		[Required]
		public Guid ExternalId
		{
			get
			{
				return _externalId;
			}
			set
			{
				this._externalId = value;
			}
		}

		private string _privateKey;
		[Required]
		public string PrivateKey
		{
			get
			{
				return _privateKey;
			}
			set
			{
				this._privateKey = value;
			}
		}

		private string _publicKey;
		[Required]
		public string PublicKey
		{
			get
			{
				return _publicKey;
			}
			set
			{
				this._publicKey = value;
			}
		}

		private string _location;
		[Required]
		public string Location
		{
			get
			{
				return _location;
			}
			set
			{
				this._location = value;
			}
		}

		private DateTime _expiration;
		[Required]
		public DateTime Expiration
		{
			get
			{
				return _expiration;
			}
			set
			{
				this._expiration = value;
			}
		}

		private string _extension;
		[Required]
		public string Extension
		{
			get
			{
				return _extension;
			}
			set
			{
				this._extension = value;
			}
		}

		private DateTime _dateCreated;
		[Required]
		public DateTime DateCreated
		{
			get
			{
				return _dateCreated;
			}
			set
			{
				this._dateCreated = value;
			}
		}

		private decimal _fileSizeInBytes;
		[Required]
		public decimal FileSizeInBytes
		{
			get
			{
				return _fileSizeInBytes;
			}
			set
			{
				this._fileSizeInBytes = value;
			}
		}

		private int _fileTypeId;
		[Required]
		public int FileTypeId
		{
			get
			{
				return _fileTypeId;
			}
			set
			{
				this._fileTypeId = value;
			}
		}

		private Nullable<int> _bucketId;
		public Nullable<int> BucketId
		{
			get
			{
				return _bucketId.IsEmptyOrZeroOrNull() ? null : _bucketId;
			}
			set
			{
				this._bucketId = value;
			}
		}

		private string _description;
		public string Description
		{
			get
			{
				return _description.IsEmptyOrZeroOrNull() ? null : _description;
			}
			set
			{
				this._description = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>efe4524ecd6ae298df87f79dad2174f1</Hash>
</Codenesium>*/
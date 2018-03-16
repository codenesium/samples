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

		public FileModel(Nullable<int> bucketId,
		                 DateTime dateCreated,
		                 string description,
		                 DateTime expiration,
		                 string extension,
		                 Guid externalId,
		                 decimal fileSizeInBytes,
		                 int fileTypeId,
		                 string location,
		                 string privateKey,
		                 string publicKey)
		{
			this.BucketId = bucketId.ToNullableInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.Description = description;
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension;
			this.ExternalId = externalId;
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.FileTypeId = fileTypeId.ToInt();
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
		}

		public FileModel(POCOFile poco)
		{
			this.DateCreated = poco.DateCreated.ToDateTime();
			this.Description = poco.Description;
			this.Expiration = poco.Expiration.ToDateTime();
			this.Extension = poco.Extension;
			this.ExternalId = poco.ExternalId;
			this.FileSizeInBytes = poco.FileSizeInBytes.ToDecimal();
			this.Location = poco.Location;
			this.PrivateKey = poco.PrivateKey;
			this.PublicKey = poco.PublicKey;

			this.BucketId = poco.BucketId.Value.ToInt();
			this.FileTypeId = poco.FileTypeId.Value.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>442686f8bd10de780a99231009f4e7f7</Hash>
</Codenesium>*/
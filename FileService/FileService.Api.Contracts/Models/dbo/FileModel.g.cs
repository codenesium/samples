using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity.Spatial;
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
		                 int id,
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
			this.Id = id.ToInt();
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
			this.Id = poco.Id.ToInt();
			this.Location = poco.Location;
			this.PrivateKey = poco.PrivateKey;
			this.PublicKey = poco.PublicKey;

			BucketId = poco.BucketId.Value.ToInt();
			FileTypeId = poco.FileTypeId.Value.ToInt();
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

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _location;
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
    <Hash>da06c339ce5e028d3640f5f8c8668aa1</Hash>
</Codenesium>*/
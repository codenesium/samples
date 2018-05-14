using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiFileModel
	{
		public ApiFileModel()
		{}

		public ApiFileModel(
			Nullable<int> bucketId,
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
			this.Description = description.ToString();
			this.Expiration = expiration.ToDateTime();
			this.Extension = extension.ToString();
			this.ExternalId = externalId.ToGuid();
			this.FileSizeInBytes = fileSizeInBytes.ToDecimal();
			this.FileTypeId = fileTypeId.ToInt();
			this.Location = location.ToString();
			this.PrivateKey = privateKey.ToString();
			this.PublicKey = publicKey.ToString();
		}

		private Nullable<int> bucketId;

		public Nullable<int> BucketId
		{
			get
			{
				return this.bucketId.IsEmptyOrZeroOrNull() ? null : this.bucketId;
			}

			set
			{
				this.bucketId = value;
			}
		}

		private DateTime dateCreated;

		[Required]
		public DateTime DateCreated
		{
			get
			{
				return this.dateCreated;
			}

			set
			{
				this.dateCreated = value;
			}
		}

		private string description;

		public string Description
		{
			get
			{
				return this.description.IsEmptyOrZeroOrNull() ? null : this.description;
			}

			set
			{
				this.description = value;
			}
		}

		private DateTime expiration;

		[Required]
		public DateTime Expiration
		{
			get
			{
				return this.expiration;
			}

			set
			{
				this.expiration = value;
			}
		}

		private string extension;

		[Required]
		public string Extension
		{
			get
			{
				return this.extension;
			}

			set
			{
				this.extension = value;
			}
		}

		private Guid externalId;

		[Required]
		public Guid ExternalId
		{
			get
			{
				return this.externalId;
			}

			set
			{
				this.externalId = value;
			}
		}

		private decimal fileSizeInBytes;

		[Required]
		public decimal FileSizeInBytes
		{
			get
			{
				return this.fileSizeInBytes;
			}

			set
			{
				this.fileSizeInBytes = value;
			}
		}

		private int fileTypeId;

		[Required]
		public int FileTypeId
		{
			get
			{
				return this.fileTypeId;
			}

			set
			{
				this.fileTypeId = value;
			}
		}

		private string location;

		[Required]
		public string Location
		{
			get
			{
				return this.location;
			}

			set
			{
				this.location = value;
			}
		}

		private string privateKey;

		[Required]
		public string PrivateKey
		{
			get
			{
				return this.privateKey;
			}

			set
			{
				this.privateKey = value;
			}
		}

		private string publicKey;

		[Required]
		public string PublicKey
		{
			get
			{
				return this.publicKey;
			}

			set
			{
				this.publicKey = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>665b90b21a432df1aadb8f33d964ee78</Hash>
</Codenesium>*/
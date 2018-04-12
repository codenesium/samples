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

		public FileModel(
			Guid externalId,
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
	}
}

/*<Codenesium>
    <Hash>f58f0c0dc6a9b1991a786f64c66c4974</Hash>
</Codenesium>*/
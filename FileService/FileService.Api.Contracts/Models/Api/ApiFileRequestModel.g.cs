using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiFileRequestModel : AbstractApiRequestModel
	{
		public ApiFileRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? bucketId,
			DateTime dateCreated,
			string description,
			DateTime expiration,
			string extension,
			Guid externalId,
			double fileSizeInByte,
			int fileTypeId,
			string location,
			string privateKey,
			string publicKey)
		{
			this.BucketId = bucketId;
			this.DateCreated = dateCreated;
			this.Description = description;
			this.Expiration = expiration;
			this.Extension = extension;
			this.ExternalId = externalId;
			this.FileSizeInByte = fileSizeInByte;
			this.FileTypeId = fileTypeId;
			this.Location = location;
			this.PrivateKey = privateKey;
			this.PublicKey = publicKey;
		}

		[JsonProperty]
		public int? BucketId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime Expiration { get; private set; }

		[Required]
		[JsonProperty]
		public string Extension { get; private set; }

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[Required]
		[JsonProperty]
		public double FileSizeInByte { get; private set; }

		[Required]
		[JsonProperty]
		public int FileTypeId { get; private set; }

		[Required]
		[JsonProperty]
		public string Location { get; private set; }

		[Required]
		[JsonProperty]
		public string PrivateKey { get; private set; }

		[Required]
		[JsonProperty]
		public string PublicKey { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f6b7fd4b2a07aee0de1b7de89ff6df98</Hash>
</Codenesium>*/
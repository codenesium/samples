using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
{
	public partial class ApiFileServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
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
			this.Id = id;
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

		[Required]
		[JsonProperty]
		public int? BucketId { get; private set; }

		[JsonProperty]
		public string BucketIdEntity { get; private set; } = RouteConstants.Buckets;

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public DateTime Expiration { get; private set; }

		[JsonProperty]
		public string Extension { get; private set; }

		[JsonProperty]
		public Guid ExternalId { get; private set; }

		[JsonProperty]
		public double FileSizeInByte { get; private set; }

		[JsonProperty]
		public int FileTypeId { get; private set; }

		[JsonProperty]
		public string FileTypeIdEntity { get; private set; } = RouteConstants.FileTypes;

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Location { get; private set; }

		[JsonProperty]
		public string PrivateKey { get; private set; }

		[JsonProperty]
		public string PublicKey { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c5a943a3aa04c6a88f7f4f7968414ac1</Hash>
</Codenesium>*/
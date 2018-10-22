using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime Expiration { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Extension { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public double FileSizeInByte { get; private set; } = default(double);

		[Required]
		[JsonProperty]
		public int FileTypeId { get; private set; }

		[Required]
		[JsonProperty]
		public string Location { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string PrivateKey { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string PublicKey { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>40c631b0a6c9c40e8a274d4eb399368b</Hash>
</Codenesium>*/
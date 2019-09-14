using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
{
	public partial class ApiFileServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiFileServerRequestModel()
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
			decimal fileSizeInByte,
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
		public decimal FileSizeInByte { get; private set; } = default(decimal);

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
    <Hash>4fa790ab7a8e0737b2c45343b54ddace</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
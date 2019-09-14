using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Client
{
	public partial class ApiFileClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiFileClientRequestModel()
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

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public DateTime Expiration { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Extension { get; private set; } = default(string);

		[JsonProperty]
		public Guid ExternalId { get; private set; } = default(Guid);

		[JsonProperty]
		public decimal FileSizeInByte { get; private set; } = default(decimal);

		[JsonProperty]
		public int FileTypeId { get; private set; }

		[JsonProperty]
		public string Location { get; private set; } = default(string);

		[JsonProperty]
		public string PrivateKey { get; private set; } = default(string);

		[JsonProperty]
		public string PublicKey { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4355f6700e5f1c1184ae4b37cbdcac56</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
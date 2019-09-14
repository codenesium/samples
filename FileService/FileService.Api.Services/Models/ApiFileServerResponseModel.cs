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
			decimal fileSizeInByte,
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
		public ApiBucketServerResponseModel BucketIdNavigation { get; private set; }

		public void SetBucketIdNavigation(ApiBucketServerResponseModel value)
		{
			this.BucketIdNavigation = value;
		}

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
		public decimal FileSizeInByte { get; private set; }

		[JsonProperty]
		public int FileTypeId { get; private set; }

		[JsonProperty]
		public string FileTypeIdEntity { get; private set; } = RouteConstants.FileTypes;

		[JsonProperty]
		public ApiFileTypeServerResponseModel FileTypeIdNavigation { get; private set; }

		public void SetFileTypeIdNavigation(ApiFileTypeServerResponseModel value)
		{
			this.FileTypeIdNavigation = value;
		}

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
    <Hash>dec023f16cae82e5a2bc15006d69637f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
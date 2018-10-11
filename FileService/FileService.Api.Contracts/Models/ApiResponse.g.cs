using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Buckets.ForEach(x => this.AddBucket(x));
			from.Files.ForEach(x => this.AddFile(x));
			from.FileTypes.ForEach(x => this.AddFileType(x));
		}

		public List<ApiBucketResponseModel> Buckets { get; private set; } = new List<ApiBucketResponseModel>();

		public List<ApiFileResponseModel> Files { get; private set; } = new List<ApiFileResponseModel>();

		public List<ApiFileTypeResponseModel> FileTypes { get; private set; } = new List<ApiFileTypeResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeBucketsValue { get; private set; } = true;

		public bool ShouldSerializeBuckets()
		{
			return this.ShouldSerializeBucketsValue;
		}

		public void AddBucket(ApiBucketResponseModel item)
		{
			if (!this.Buckets.Any(x => x.Id == item.Id))
			{
				this.Buckets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFilesValue { get; private set; } = true;

		public bool ShouldSerializeFiles()
		{
			return this.ShouldSerializeFilesValue;
		}

		public void AddFile(ApiFileResponseModel item)
		{
			if (!this.Files.Any(x => x.Id == item.Id))
			{
				this.Files.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFileTypesValue { get; private set; } = true;

		public bool ShouldSerializeFileTypes()
		{
			return this.ShouldSerializeFileTypesValue;
		}

		public void AddFileType(ApiFileTypeResponseModel item)
		{
			if (!this.FileTypes.Any(x => x.Id == item.Id))
			{
				this.FileTypes.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Buckets.Count == 0)
			{
				this.ShouldSerializeBucketsValue = false;
			}

			if (this.Files.Count == 0)
			{
				this.ShouldSerializeFilesValue = false;
			}

			if (this.FileTypes.Count == 0)
			{
				this.ShouldSerializeFileTypesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>67514358cc4e25e6a5a9fd87af02ff00</Hash>
</Codenesium>*/
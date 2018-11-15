using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Client
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

		public List<ApiBucketClientResponseModel> Buckets { get; private set; } = new List<ApiBucketClientResponseModel>();

		public List<ApiFileClientResponseModel> Files { get; private set; } = new List<ApiFileClientResponseModel>();

		public List<ApiFileTypeClientResponseModel> FileTypes { get; private set; } = new List<ApiFileTypeClientResponseModel>();

		public void AddBucket(ApiBucketClientResponseModel item)
		{
			if (!this.Buckets.Any(x => x.Id == item.Id))
			{
				this.Buckets.Add(item);
			}
		}

		public void AddFile(ApiFileClientResponseModel item)
		{
			if (!this.Files.Any(x => x.Id == item.Id))
			{
				this.Files.Add(item);
			}
		}

		public void AddFileType(ApiFileTypeClientResponseModel item)
		{
			if (!this.FileTypes.Any(x => x.Id == item.Id))
			{
				this.FileTypes.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>5d1c2c900b52b4bd6c617bef6ff1532c</Hash>
</Codenesium>*/
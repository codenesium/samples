using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FileServiceNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "Value")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "Object")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

		public void Merge(ApiResponse from)
		{
			from.Buckets.ForEach(x => this.AddBucket(x));
			from.Files.ForEach(x => this.AddFile(x));
			from.FileTypes.ForEach(x => this.AddFileType(x));
			from.VersionInfoes.ForEach(x => this.AddVersionInfo(x));
		}

		public List<POCOBucket> Buckets { get; private set; } = new List<POCOBucket>();

		public List<POCOFile> Files { get; private set; } = new List<POCOFile>();

		public List<POCOFileType> FileTypes { get; private set; } = new List<POCOFileType>();

		public List<POCOVersionInfo> VersionInfoes { get; private set; } = new List<POCOVersionInfo>();

		[JsonIgnore]
		public bool ShouldSerializeBucketsValue { get; set; } = true;

		public bool ShouldSerializeBuckets()
		{
			return this.ShouldSerializeBucketsValue;
		}

		public void AddBucket(POCOBucket item)
		{
			if (!this.Buckets.Any(x => x.Id == item.Id))
			{
				this.Buckets.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFilesValue { get; set; } = true;

		public bool ShouldSerializeFiles()
		{
			return this.ShouldSerializeFilesValue;
		}

		public void AddFile(POCOFile item)
		{
			if (!this.Files.Any(x => x.Id == item.Id))
			{
				this.Files.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFileTypesValue { get; set; } = true;

		public bool ShouldSerializeFileTypes()
		{
			return this.ShouldSerializeFileTypesValue;
		}

		public void AddFileType(POCOFileType item)
		{
			if (!this.FileTypes.Any(x => x.Id == item.Id))
			{
				this.FileTypes.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionInfoesValue { get; set; } = true;

		public bool ShouldSerializeVersionInfoes()
		{
			return this.ShouldSerializeVersionInfoesValue;
		}

		public void AddVersionInfo(POCOVersionInfo item)
		{
			if (!this.VersionInfoes.Any(x => x.Version == item.Version))
			{
				this.VersionInfoes.Add(item);
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

			if (this.VersionInfoes.Count == 0)
			{
				this.ShouldSerializeVersionInfoesValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5f7b3c4b91f776e4ebff788600663356</Hash>
</Codenesium>*/
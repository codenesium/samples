using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FileServiceNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		public T Value { get; set; }

		public string Href
		{
			get
			{
				return $"/{this.ReferenceObjectName}/{this.Value.ToString()}";
			}
		}

		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class Response
	{
		public Response()
		{}
		public List<POCOBucket> Buckets { get; private set; } = new List<POCOBucket>();

		public List<POCOFile> Files { get; private set; } = new List<POCOFile>();

		public List<POCOFileType> FileTypes { get; private set; } = new List<POCOFileType>();

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
    <Hash>0240329c495710010de10295891fc4b8</Hash>
</Codenesium>*/
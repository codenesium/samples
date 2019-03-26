using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiDocumentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			Guid rowguid,
			int changeNumber,
			byte[] document1,
			short? documentLevel,
			string documentSummary,
			string fileExtension,
			string fileName,
			bool folderFlag,
			DateTime modifiedDate,
			int owner,
			string revision,
			int status,
			string title)
		{
			this.Rowguid = rowguid;
			this.ChangeNumber = changeNumber;
			this.Document1 = document1;
			this.DocumentLevel = documentLevel;
			this.DocumentSummary = documentSummary;
			this.FileExtension = fileExtension;
			this.FileName = fileName;
			this.FolderFlag = folderFlag;
			this.ModifiedDate = modifiedDate;
			this.Owner = owner;
			this.Revision = revision;
			this.Status = status;
			this.Title = title;
		}

		[JsonProperty]
		public int ChangeNumber { get; private set; }

		[JsonProperty]
		public byte[] Document1 { get; private set; }

		[JsonProperty]
		public short? DocumentLevel { get; private set; }

		[JsonProperty]
		public string DocumentSummary { get; private set; }

		[JsonProperty]
		public string FileExtension { get; private set; }

		[JsonProperty]
		public string FileName { get; private set; }

		[JsonProperty]
		public bool FolderFlag { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int Owner { get; private set; }

		[JsonProperty]
		public string Revision { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int Status { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0462a0e4e3f1f6cdc0685a513eaf21f5</Hash>
</Codenesium>*/
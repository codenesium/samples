using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDocumentResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public byte[] Document1 { get; private set; }

		[Required]
		[JsonProperty]
		public short? DocumentLevel { get; private set; }

		[Required]
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
    <Hash>23ea9ef767b6115fd1dfd14a1d3b4dd9</Hash>
</Codenesium>*/
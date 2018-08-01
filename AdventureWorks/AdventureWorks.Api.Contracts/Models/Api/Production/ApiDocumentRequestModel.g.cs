using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDocumentRequestModel : AbstractApiRequestModel
	{
		public ApiDocumentRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[Required]
		[JsonProperty]
		public int ChangeNumber { get; private set; }

		[JsonProperty]
		public byte[] Document1 { get; private set; }

		[JsonProperty]
		public short? DocumentLevel { get; private set; }

		[JsonProperty]
		public string DocumentSummary { get; private set; }

		[Required]
		[JsonProperty]
		public string FileExtension { get; private set; }

		[Required]
		[JsonProperty]
		public string FileName { get; private set; }

		[Required]
		[JsonProperty]
		public bool FolderFlag { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int Owner { get; private set; }

		[Required]
		[JsonProperty]
		public string Revision { get; private set; }

		[Required]
		[JsonProperty]
		public int Status { get; private set; }

		[Required]
		[JsonProperty]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>980379fd618c8da35498638fb321a75b</Hash>
</Codenesium>*/
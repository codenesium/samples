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
		public int ChangeNumber { get; private set; } = default(int);

		[JsonProperty]
		public byte[] Document1 { get; private set; } = default(byte[]);

		[JsonProperty]
		public short? DocumentLevel { get; private set; } = default(short);

		[JsonProperty]
		public string DocumentSummary { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FileExtension { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FileName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool FolderFlag { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int Owner { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Revision { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int Status { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Title { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>fdd52cbb9d83b0d0959fec0dfedd488d</Hash>
</Codenesium>*/
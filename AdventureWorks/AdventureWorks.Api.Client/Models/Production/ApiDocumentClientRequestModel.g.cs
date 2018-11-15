using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiDocumentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDocumentClientRequestModel()
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

		[JsonProperty]
		public int ChangeNumber { get; private set; } = default(int);

		[JsonProperty]
		public byte[] Document1 { get; private set; } = default(byte[]);

		[JsonProperty]
		public short? DocumentLevel { get; private set; } = default(short);

		[JsonProperty]
		public string DocumentSummary { get; private set; } = default(string);

		[JsonProperty]
		public string FileExtension { get; private set; } = default(string);

		[JsonProperty]
		public string FileName { get; private set; } = default(string);

		[JsonProperty]
		public bool FolderFlag { get; private set; } = default(bool);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int Owner { get; private set; } = default(int);

		[JsonProperty]
		public string Revision { get; private set; } = default(string);

		[JsonProperty]
		public int Status { get; private set; } = default(int);

		[JsonProperty]
		public string Title { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>549aa52c29416023fb07ca597f404298</Hash>
</Codenesium>*/
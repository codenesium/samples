using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCODocument: AbstractPOCO
	{
		public POCODocument() : base()
		{}

		public POCODocument(
			int changeNumber,
			byte[] document1,
			Nullable<short> documentLevel,
			Guid documentNode,
			string documentSummary,
			string fileExtension,
			string fileName,
			bool folderFlag,
			DateTime modifiedDate,
			int owner,
			string revision,
			Guid rowguid,
			int status,
			string title)
		{
			this.ChangeNumber = changeNumber.ToInt();
			this.Document1 = document1;
			this.DocumentLevel = documentLevel;
			this.DocumentNode = documentNode.ToGuid();
			this.DocumentSummary = documentSummary;
			this.FileExtension = fileExtension;
			this.FileName = fileName;
			this.FolderFlag = folderFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Owner = owner.ToInt();
			this.Revision = revision;
			this.Rowguid = rowguid.ToGuid();
			this.Status = status.ToInt();
			this.Title = title;
		}

		public int ChangeNumber { get; set; }
		public byte[] Document1 { get; set; }
		public Nullable<short> DocumentLevel { get; set; }
		public Guid DocumentNode { get; set; }
		public string DocumentSummary { get; set; }
		public string FileExtension { get; set; }
		public string FileName { get; set; }
		public bool FolderFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int Owner { get; set; }
		public string Revision { get; set; }
		public Guid Rowguid { get; set; }
		public int Status { get; set; }
		public string Title { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeChangeNumberValue { get; set; } = true;

		public bool ShouldSerializeChangeNumber()
		{
			return this.ShouldSerializeChangeNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocument1Value { get; set; } = true;

		public bool ShouldSerializeDocument1()
		{
			return this.ShouldSerializeDocument1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentLevelValue { get; set; } = true;

		public bool ShouldSerializeDocumentLevel()
		{
			return this.ShouldSerializeDocumentLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentNodeValue { get; set; } = true;

		public bool ShouldSerializeDocumentNode()
		{
			return this.ShouldSerializeDocumentNodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentSummaryValue { get; set; } = true;

		public bool ShouldSerializeDocumentSummary()
		{
			return this.ShouldSerializeDocumentSummaryValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileExtensionValue { get; set; } = true;

		public bool ShouldSerializeFileExtension()
		{
			return this.ShouldSerializeFileExtensionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileNameValue { get; set; } = true;

		public bool ShouldSerializeFileName()
		{
			return this.ShouldSerializeFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFolderFlagValue { get; set; } = true;

		public bool ShouldSerializeFolderFlag()
		{
			return this.ShouldSerializeFolderFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOwnerValue { get; set; } = true;

		public bool ShouldSerializeOwner()
		{
			return this.ShouldSerializeOwnerValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionValue { get; set; } = true;

		public bool ShouldSerializeRevision()
		{
			return this.ShouldSerializeRevisionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue { get; set; } = true;

		public bool ShouldSerializeStatus()
		{
			return this.ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTitleValue { get; set; } = true;

		public bool ShouldSerializeTitle()
		{
			return this.ShouldSerializeTitleValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeChangeNumberValue = false;
			this.ShouldSerializeDocument1Value = false;
			this.ShouldSerializeDocumentLevelValue = false;
			this.ShouldSerializeDocumentNodeValue = false;
			this.ShouldSerializeDocumentSummaryValue = false;
			this.ShouldSerializeFileExtensionValue = false;
			this.ShouldSerializeFileNameValue = false;
			this.ShouldSerializeFolderFlagValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeOwnerValue = false;
			this.ShouldSerializeRevisionValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeStatusValue = false;
			this.ShouldSerializeTitleValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ba3f6de4fd8b940b8dc5eab765f4d6aa</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCODocument
	{
		public POCODocument()
		{}

		public POCODocument(
			Guid documentNode,
			Nullable<short> documentLevel,
			string title,
			int owner,
			bool folderFlag,
			string fileName,
			string fileExtension,
			string revision,
			int changeNumber,
			int status,
			string documentSummary,
			byte[] document1,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.DocumentNode = documentNode;
			this.DocumentLevel = documentLevel;
			this.Title = title;
			this.FolderFlag = folderFlag;
			this.FileName = fileName;
			this.FileExtension = fileExtension;
			this.Revision = revision;
			this.ChangeNumber = changeNumber.ToInt();
			this.Status = status;
			this.DocumentSummary = documentSummary;
			this.Document1 = document1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.Owner = new ReferenceEntity<int>(owner,
			                                      "Employee");
		}

		public Guid DocumentNode { get; set; }
		public Nullable<short> DocumentLevel { get; set; }
		public string Title { get; set; }
		public ReferenceEntity<int> Owner { get; set; }
		public bool FolderFlag { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public string Revision { get; set; }
		public int ChangeNumber { get; set; }
		public int Status { get; set; }
		public string DocumentSummary { get; set; }
		public byte[] Document1 { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDocumentNodeValue { get; set; } = true;

		public bool ShouldSerializeDocumentNode()
		{
			return this.ShouldSerializeDocumentNodeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentLevelValue { get; set; } = true;

		public bool ShouldSerializeDocumentLevel()
		{
			return this.ShouldSerializeDocumentLevelValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTitleValue { get; set; } = true;

		public bool ShouldSerializeTitle()
		{
			return this.ShouldSerializeTitleValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOwnerValue { get; set; } = true;

		public bool ShouldSerializeOwner()
		{
			return this.ShouldSerializeOwnerValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFolderFlagValue { get; set; } = true;

		public bool ShouldSerializeFolderFlag()
		{
			return this.ShouldSerializeFolderFlagValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileNameValue { get; set; } = true;

		public bool ShouldSerializeFileName()
		{
			return this.ShouldSerializeFileNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFileExtensionValue { get; set; } = true;

		public bool ShouldSerializeFileExtension()
		{
			return this.ShouldSerializeFileExtensionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionValue { get; set; } = true;

		public bool ShouldSerializeRevision()
		{
			return this.ShouldSerializeRevisionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChangeNumberValue { get; set; } = true;

		public bool ShouldSerializeChangeNumber()
		{
			return this.ShouldSerializeChangeNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue { get; set; } = true;

		public bool ShouldSerializeStatus()
		{
			return this.ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocumentSummaryValue { get; set; } = true;

		public bool ShouldSerializeDocumentSummary()
		{
			return this.ShouldSerializeDocumentSummaryValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDocument1Value { get; set; } = true;

		public bool ShouldSerializeDocument1()
		{
			return this.ShouldSerializeDocument1Value;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDocumentNodeValue = false;
			this.ShouldSerializeDocumentLevelValue = false;
			this.ShouldSerializeTitleValue = false;
			this.ShouldSerializeOwnerValue = false;
			this.ShouldSerializeFolderFlagValue = false;
			this.ShouldSerializeFileNameValue = false;
			this.ShouldSerializeFileExtensionValue = false;
			this.ShouldSerializeRevisionValue = false;
			this.ShouldSerializeChangeNumberValue = false;
			this.ShouldSerializeStatusValue = false;
			this.ShouldSerializeDocumentSummaryValue = false;
			this.ShouldSerializeDocument1Value = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>51f1349b49923496720ef62d5a8727db</Hash>
</Codenesium>*/
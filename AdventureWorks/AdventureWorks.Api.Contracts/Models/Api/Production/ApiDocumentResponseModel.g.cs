using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDocumentResponseModel: AbstractApiResponseModel
	{
		public ApiDocumentResponseModel() : base()
		{}

		public void SetProperties(
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

		public int ChangeNumber { get; private set; }
		public byte[] Document1 { get; private set; }
		public Nullable<short> DocumentLevel { get; private set; }
		public Guid DocumentNode { get; private set; }
		public string DocumentSummary { get; private set; }
		public string FileExtension { get; private set; }
		public string FileName { get; private set; }
		public bool FolderFlag { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int Owner { get; private set; }
		public string Revision { get; private set; }
		public Guid Rowguid { get; private set; }
		public int Status { get; private set; }
		public string Title { get; private set; }

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
    <Hash>42bf112de2f03960345823cfa9957ebf</Hash>
</Codenesium>*/
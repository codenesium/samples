using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiDocumentResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int changeNumber,
                        byte[] document1,
                        Nullable<short> documentLevel,
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
                        this.Rowguid = rowguid;
                        this.Status = status;
                        this.Title = title;
                }

                public int ChangeNumber { get; private set; }

                public byte[] Document1 { get; private set; }

                public Nullable<short> DocumentLevel { get; private set; }

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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeChangeNumberValue = false;
                        this.ShouldSerializeDocument1Value = false;
                        this.ShouldSerializeDocumentLevelValue = false;
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
    <Hash>84aa262a248eaa28f7e5cf676668154f</Hash>
</Codenesium>*/
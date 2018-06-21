using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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

                private int changeNumber;

                [Required]
                public int ChangeNumber
                {
                        get
                        {
                                return this.changeNumber;
                        }

                        set
                        {
                                this.changeNumber = value;
                        }
                }

                private byte[] document1;

                public byte[] Document1
                {
                        get
                        {
                                return this.document1.IsEmptyOrZeroOrNull() ? null : this.document1;
                        }

                        set
                        {
                                this.document1 = value;
                        }
                }

                private Nullable<short> documentLevel;

                public Nullable<short> DocumentLevel
                {
                        get
                        {
                                return this.documentLevel.IsEmptyOrZeroOrNull() ? null : this.documentLevel;
                        }

                        set
                        {
                                this.documentLevel = value;
                        }
                }

                private string documentSummary;

                public string DocumentSummary
                {
                        get
                        {
                                return this.documentSummary.IsEmptyOrZeroOrNull() ? null : this.documentSummary;
                        }

                        set
                        {
                                this.documentSummary = value;
                        }
                }

                private string fileExtension;

                [Required]
                public string FileExtension
                {
                        get
                        {
                                return this.fileExtension;
                        }

                        set
                        {
                                this.fileExtension = value;
                        }
                }

                private string fileName;

                [Required]
                public string FileName
                {
                        get
                        {
                                return this.fileName;
                        }

                        set
                        {
                                this.fileName = value;
                        }
                }

                private bool folderFlag;

                [Required]
                public bool FolderFlag
                {
                        get
                        {
                                return this.folderFlag;
                        }

                        set
                        {
                                this.folderFlag = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private int owner;

                [Required]
                public int Owner
                {
                        get
                        {
                                return this.owner;
                        }

                        set
                        {
                                this.owner = value;
                        }
                }

                private string revision;

                [Required]
                public string Revision
                {
                        get
                        {
                                return this.revision;
                        }

                        set
                        {
                                this.revision = value;
                        }
                }

                private int status;

                [Required]
                public int Status
                {
                        get
                        {
                                return this.status;
                        }

                        set
                        {
                                this.status = value;
                        }
                }

                private string title;

                [Required]
                public string Title
                {
                        get
                        {
                                return this.title;
                        }

                        set
                        {
                                this.title = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>2e8476a9bac4be59c8b93580bcd58dd0</Hash>
</Codenesium>*/
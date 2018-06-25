using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBODocument : AbstractBusinessObject
        {
                public AbstractBODocument()
                        : base()
                {
                }

                public virtual void SetProperties(Guid rowguid,
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
                        this.Rowguid = rowguid;
                        this.Status = status;
                        this.Title = title;
                }

                public int ChangeNumber { get; private set; }

                public byte[] Document1 { get; private set; }

                public short? DocumentLevel { get; private set; }

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
        }
}

/*<Codenesium>
    <Hash>f7b8c415832fa0b58b6bd335e5b95c69</Hash>
</Codenesium>*/
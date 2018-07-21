using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Document", Schema="Production")]
        public partial class Document : AbstractEntity
        {
                public Document()
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

                [Column("ChangeNumber")]
                public int ChangeNumber { get; private set; }

                [Column("Document")]
                public byte[] Document1 { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("DocumentLevel")]
                public short? DocumentLevel { get; private set; }

                [Column("DocumentSummary")]
                public string DocumentSummary { get; private set; }

                [Column("FileExtension")]
                public string FileExtension { get; private set; }

                [Column("FileName")]
                public string FileName { get; private set; }

                [Column("FolderFlag")]
                public bool FolderFlag { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Owner")]
                public int Owner { get; private set; }

                [Column("Revision")]
                public string Revision { get; private set; }

                [Key]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("Status")]
                public int Status { get; private set; }

                [Column("Title")]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>04ab2ad1b52cebd980b71b50817e5bf5</Hash>
</Codenesium>*/
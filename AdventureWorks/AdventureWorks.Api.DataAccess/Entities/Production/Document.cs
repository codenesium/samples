using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Document", Schema="Production")]
        public partial class Document: AbstractEntity
        {
                public Document()
                {
                }

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
                        this.ChangeNumber = changeNumber;
                        this.Document1 = document1;
                        this.DocumentLevel = documentLevel;
                        this.DocumentNode = documentNode;
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

                [Column("ChangeNumber", TypeName="int")]
                public int ChangeNumber { get; private set; }

                [Column("Document", TypeName="varbinary(-1)")]
                public byte[] Document1 { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("DocumentLevel", TypeName="smallint")]
                public Nullable<short> DocumentLevel { get; private set; }

                [Key]
                [Column("DocumentNode", TypeName="hierarchyid(892)")]
                public Guid DocumentNode { get; private set; }

                [Column("DocumentSummary", TypeName="nvarchar(-1)")]
                public string DocumentSummary { get; private set; }

                [Column("FileExtension", TypeName="nvarchar(8)")]
                public string FileExtension { get; private set; }

                [Column("FileName", TypeName="nvarchar(400)")]
                public string FileName { get; private set; }

                [Column("FolderFlag", TypeName="bit")]
                public bool FolderFlag { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Owner", TypeName="int")]
                public int Owner { get; private set; }

                [Column("Revision", TypeName="nchar(5)")]
                public string Revision { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("Status", TypeName="tinyint")]
                public int Status { get; private set; }

                [Column("Title", TypeName="nvarchar(50)")]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>35f31652d5cd8c198ffd558b7088d9d9</Hash>
</Codenesium>*/
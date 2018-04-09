using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Document", Schema="Production")]
	public partial class EFDocument
	{
		public EFDocument()
		{}

		public void SetProperties(Guid documentNode,
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
			this.Owner = owner.ToInt();
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
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode {get; set;}

		[Column("DocumentLevel", TypeName="smallint")]
		public Nullable<short> DocumentLevel {get; set;}

		[Column("Title", TypeName="nvarchar(50)")]
		public string Title {get; set;}

		[Column("Owner", TypeName="int")]
		public int Owner {get; set;}

		[Column("FolderFlag", TypeName="bit")]
		public bool FolderFlag {get; set;}

		[Column("FileName", TypeName="nvarchar(400)")]
		public string FileName {get; set;}

		[Column("FileExtension", TypeName="nvarchar(8)")]
		public string FileExtension {get; set;}

		[Column("Revision", TypeName="nchar(5)")]
		public string Revision {get; set;}

		[Column("ChangeNumber", TypeName="int")]
		public int ChangeNumber {get; set;}

		[Column("Status", TypeName="tinyint")]
		public int Status {get; set;}

		[Column("DocumentSummary", TypeName="nvarchar(-1)")]
		public string DocumentSummary {get; set;}

		[Column("Document", TypeName="varbinary(-1)")]
		public byte[] Document1 {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>0fe1844ef6e5859e5e884e9ed27a3506</Hash>
</Codenesium>*/
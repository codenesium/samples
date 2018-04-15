using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Document", Schema="Production")]
	public partial class EFDocument
	{
		public EFDocument()
		{}

		public void SetProperties(
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
			this.Title = title.ToString();
			this.Owner = owner.ToInt();
			this.FolderFlag = folderFlag.ToBoolean();
			this.FileName = fileName.ToString();
			this.FileExtension = fileExtension.ToString();
			this.Revision = revision.ToString();
			this.ChangeNumber = changeNumber.ToInt();
			this.Status = status.ToInt();
			this.DocumentSummary = documentSummary.ToString();
			this.Document1 = document1;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode { get; set; }

		[Column("DocumentLevel", TypeName="smallint")]
		public Nullable<short> DocumentLevel { get; set; }

		[Column("Title", TypeName="nvarchar(50)")]
		public string Title { get; set; }

		[Column("Owner", TypeName="int")]
		public int Owner { get; set; }

		[Column("FolderFlag", TypeName="bit")]
		public bool FolderFlag { get; set; }

		[Column("FileName", TypeName="nvarchar(400)")]
		public string FileName { get; set; }

		[Column("FileExtension", TypeName="nvarchar(8)")]
		public string FileExtension { get; set; }

		[Column("Revision", TypeName="nchar(5)")]
		public string Revision { get; set; }

		[Column("ChangeNumber", TypeName="int")]
		public int ChangeNumber { get; set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; set; }

		[Column("DocumentSummary", TypeName="nvarchar(-1)")]
		public string DocumentSummary { get; set; }

		[Column("Document", TypeName="varbinary(-1)")]
		public byte[] Document1 { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("Owner")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>a6509cdc95d08d01aad8cb7e7c16ac8b</Hash>
</Codenesium>*/
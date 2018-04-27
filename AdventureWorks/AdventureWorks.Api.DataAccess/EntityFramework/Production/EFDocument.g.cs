using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Document", Schema="Production")]
	public partial class EFDocument: AbstractEntityFrameworkPOCO
	{
		public EFDocument()
		{}

		public void SetProperties(
			Guid documentNode,
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
			this.ChangeNumber = changeNumber.ToInt();
			this.Document1 = document1;
			this.DocumentLevel = documentLevel;
			this.DocumentNode = documentNode;
			this.DocumentSummary = documentSummary.ToString();
			this.FileExtension = fileExtension.ToString();
			this.FileName = fileName.ToString();
			this.FolderFlag = folderFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Owner = owner.ToInt();
			this.Revision = revision.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.Status = status.ToInt();
			this.Title = title.ToString();
		}

		[Column("ChangeNumber", TypeName="int")]
		public int ChangeNumber { get; set; }

		[Column("Document", TypeName="varbinary(-1)")]
		public byte[] Document1 { get; set; }

		[Column("DocumentLevel", TypeName="smallint")]
		public Nullable<short> DocumentLevel { get; set; }

		[Key]
		[Column("DocumentNode", TypeName="hierarchyid(892)")]
		public Guid DocumentNode { get; set; }

		[Column("DocumentSummary", TypeName="nvarchar(-1)")]
		public string DocumentSummary { get; set; }

		[Column("FileExtension", TypeName="nvarchar(8)")]
		public string FileExtension { get; set; }

		[Column("FileName", TypeName="nvarchar(400)")]
		public string FileName { get; set; }

		[Column("FolderFlag", TypeName="bit")]
		public bool FolderFlag { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Owner", TypeName="int")]
		public int Owner { get; set; }

		[Column("Revision", TypeName="nchar(5)")]
		public string Revision { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; set; }

		[Column("Title", TypeName="nvarchar(50)")]
		public string Title { get; set; }

		[ForeignKey("Owner")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>14ad68521c874a0275259efa1e2d0b99</Hash>
</Codenesium>*/
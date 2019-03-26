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
			Guid rowguid,
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
			this.Rowguid = rowguid;
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

		[Column("ChangeNumber")]
		public virtual int ChangeNumber { get; private set; }

		[Column("Document")]
		public virtual byte[] Document1 { get; private set; }

		[Column("DocumentLevel")]
		public virtual short? DocumentLevel { get; private set; }

		[Column("DocumentSummary")]
		public virtual string DocumentSummary { get; private set; }

		[MaxLength(8)]
		[Column("FileExtension")]
		public virtual string FileExtension { get; private set; }

		[MaxLength(400)]
		[Column("FileName")]
		public virtual string FileName { get; private set; }

		[Column("FolderFlag")]
		public virtual bool FolderFlag { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("Owner")]
		public virtual int Owner { get; private set; }

		[MaxLength(5)]
		[Column("Revision")]
		public virtual string Revision { get; private set; }

		[Key]
		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("Status")]
		public virtual int Status { get; private set; }

		[MaxLength(50)]
		[Column("Title")]
		public virtual string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a4f8c4df7bc8eaa5fdb6a7d6d52b6765</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTODocument: AbstractDTO
	{
		public DTODocument() : base()
		{}

		public void SetProperties(Guid documentNode,
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

		public int ChangeNumber { get; set; }
		public byte[] Document1 { get; set; }
		public Nullable<short> DocumentLevel { get; set; }
		public Guid DocumentNode { get; set; }
		public string DocumentSummary { get; set; }
		public string FileExtension { get; set; }
		public string FileName { get; set; }
		public bool FolderFlag { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int Owner { get; set; }
		public string Revision { get; set; }
		public Guid Rowguid { get; set; }
		public int Status { get; set; }
		public string Title { get; set; }
	}
}

/*<Codenesium>
    <Hash>71240bf2d9b8a8b418ab8441fb48229a</Hash>
</Codenesium>*/
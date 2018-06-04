using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BODocument: AbstractBusinessObject
	{
		public BODocument() : base()
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

		public int ChangeNumber { get; private set; }
		public byte[] Document1 { get; private set; }
		public Nullable<short> DocumentLevel { get; private set; }
		public Guid DocumentNode { get; private set; }
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
    <Hash>c24e5842ac204358898544560a5814dd</Hash>
</Codenesium>*/
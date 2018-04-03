using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class DocumentModelValidator: AbstractDocumentModelValidator,IDocumentModelValidator
	{
		public DocumentModelValidator()
		{   }

		public void CreateMode()
		{
			this.DocumentLevelRules();
			this.TitleRules();
			this.OwnerRules();
			this.FolderFlagRules();
			this.FileNameRules();
			this.FileExtensionRules();
			this.RevisionRules();
			this.ChangeNumberRules();
			this.StatusRules();
			this.DocumentSummaryRules();
			this.DocumentRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DocumentLevelRules();
			this.TitleRules();
			this.OwnerRules();
			this.FolderFlagRules();
			this.FileNameRules();
			this.FileExtensionRules();
			this.RevisionRules();
			this.ChangeNumberRules();
			this.StatusRules();
			this.DocumentSummaryRules();
			this.DocumentRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.DocumentLevelRules();
			this.TitleRules();
			this.OwnerRules();
			this.FolderFlagRules();
			this.FileNameRules();
			this.FileExtensionRules();
			this.RevisionRules();
			this.ChangeNumberRules();
			this.StatusRules();
			this.DocumentSummaryRules();
			this.DocumentRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>f1ee6d6e713865d065a74f8b0d68ba02</Hash>
</Codenesium>*/
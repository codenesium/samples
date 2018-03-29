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
			this.Document1Rules();
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
			this.Document1Rules();
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
			this.Document1Rules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>5d7b66d631fb5383dab7b5c359afe107</Hash>
</Codenesium>*/
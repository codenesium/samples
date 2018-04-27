using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class DocumentModelValidator: AbstractDocumentModelValidator, IDocumentModelValidator
	{
		public DocumentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(DocumentModel model)
		{
			this.ChangeNumberRules();
			this.Document1Rules();
			this.DocumentLevelRules();
			this.DocumentSummaryRules();
			this.FileExtensionRules();
			this.FileNameRules();
			this.FolderFlagRules();
			this.ModifiedDateRules();
			this.OwnerRules();
			this.RevisionRules();
			this.RowguidRules();
			this.StatusRules();
			this.TitleRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(Guid id, DocumentModel model)
		{
			this.ChangeNumberRules();
			this.Document1Rules();
			this.DocumentLevelRules();
			this.DocumentSummaryRules();
			this.FileExtensionRules();
			this.FileNameRules();
			this.FolderFlagRules();
			this.ModifiedDateRules();
			this.OwnerRules();
			this.RevisionRules();
			this.RowguidRules();
			this.StatusRules();
			this.TitleRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(Guid id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7b4a2323b97622a70b57499d1bd12f45</Hash>
</Codenesium>*/
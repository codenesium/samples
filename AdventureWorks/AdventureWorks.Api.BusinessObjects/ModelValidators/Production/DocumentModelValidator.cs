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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(Guid id, DocumentModel model)
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(Guid id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>3876a33721f06d7b844de7550a9cf9fe</Hash>
</Codenesium>*/
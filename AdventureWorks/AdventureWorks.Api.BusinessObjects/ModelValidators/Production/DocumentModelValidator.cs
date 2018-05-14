using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDocumentModelValidator: AbstractApiDocumentModelValidator, IApiDocumentModelValidator
	{
		public ApiDocumentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDocumentModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentModel model)
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
    <Hash>2a4c09842240ad756a7384c1dea875b9</Hash>
</Codenesium>*/
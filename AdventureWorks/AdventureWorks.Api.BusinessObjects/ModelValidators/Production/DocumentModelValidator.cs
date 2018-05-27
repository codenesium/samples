using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDocumentRequestModelValidator: AbstractApiDocumentRequestModelValidator, IApiDocumentRequestModelValidator
	{
		public ApiDocumentRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDocumentRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentRequestModel model)
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
    <Hash>c7e1e69672254e7d658890e1b61d3402</Hash>
</Codenesium>*/
using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiDocumentRequestModelValidator: AbstractApiDocumentRequestModelValidator, IApiDocumentRequestModelValidator
        {
                public ApiDocumentRequestModelValidator(IDocumentRepository documentRepository)
                        : base(documentRepository)
                {
                }

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
                        this.StatusRules();
                        this.TitleRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(Guid id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e32c257eb1fc7ab1f8dcada5dbaa5244</Hash>
</Codenesium>*/
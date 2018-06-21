using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiDocumentRequestModelValidator : AbstractApiDocumentRequestModelValidator, IApiDocumentRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>81daac28f530b2f03c29fa141e9baa55</Hash>
</Codenesium>*/
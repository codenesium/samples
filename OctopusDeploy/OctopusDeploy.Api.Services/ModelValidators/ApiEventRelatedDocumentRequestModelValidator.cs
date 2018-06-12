using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiEventRelatedDocumentRequestModelValidator: AbstractApiEventRelatedDocumentRequestModelValidator, IApiEventRelatedDocumentRequestModelValidator
        {
                public ApiEventRelatedDocumentRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEventRelatedDocumentRequestModel model)
                {
                        this.EventIdRules();
                        this.RelatedDocumentIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRelatedDocumentRequestModel model)
                {
                        this.EventIdRules();
                        this.RelatedDocumentIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>66ff328742ffb634e12f17027ebacbbc</Hash>
</Codenesium>*/
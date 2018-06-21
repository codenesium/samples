using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiEventRelatedDocumentRequestModelValidator : AbstractApiEventRelatedDocumentRequestModelValidator, IApiEventRelatedDocumentRequestModelValidator
        {
                public ApiEventRelatedDocumentRequestModelValidator(IEventRelatedDocumentRepository eventRelatedDocumentRepository)
                        : base(eventRelatedDocumentRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>832ed0d80df607e31cc1917c5919bb12</Hash>
</Codenesium>*/
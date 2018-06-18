using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiEventRelatedDocumentRequestModelValidator: AbstractApiEventRelatedDocumentRequestModelValidator, IApiEventRelatedDocumentRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e08698029b1c1febdbcb2fc96cfc3d5d</Hash>
</Codenesium>*/
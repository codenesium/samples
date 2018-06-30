using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepStatusRequestModelValidator : AbstractApiPipelineStepStatusRequestModelValidator, IApiPipelineStepStatusRequestModelValidator
        {
                public ApiPipelineStepStatusRequestModelValidator(IPipelineStepStatusRepository pipelineStepStatusRepository)
                        : base(pipelineStepStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>0a375c1f96830bd087641512cb0f4601</Hash>
</Codenesium>*/
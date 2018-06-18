using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepStatusRequestModelValidator: AbstractApiPipelineStepStatusRequestModelValidator, IApiPipelineStepStatusRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>c8e9ec958207e0da9dd0e39bc51669cb</Hash>
</Codenesium>*/
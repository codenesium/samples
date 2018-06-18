using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepRequestModelValidator: AbstractApiPipelineStepRequestModelValidator, IApiPipelineStepRequestModelValidator
        {
                public ApiPipelineStepRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
                        : base(pipelineStepRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model)
                {
                        this.NameRules();
                        this.PipelineStepStatusIdRules();
                        this.ShipperIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model)
                {
                        this.NameRules();
                        this.PipelineStepStatusIdRules();
                        this.ShipperIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>f3199b3e8cbd453e7d5b92d23a2188e3</Hash>
</Codenesium>*/
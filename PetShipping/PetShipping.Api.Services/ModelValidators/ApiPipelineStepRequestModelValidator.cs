using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepRequestModelValidator: AbstractApiPipelineStepRequestModelValidator, IApiPipelineStepRequestModelValidator
        {
                public ApiPipelineStepRequestModelValidator()
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
    <Hash>0912137bc2d9383f6ee2c4b869812524</Hash>
</Codenesium>*/
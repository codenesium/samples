using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepRequestModelValidator : AbstractApiPipelineStepRequestModelValidator, IApiPipelineStepRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>e4ace18648309f714c2a3120a591b57e</Hash>
</Codenesium>*/
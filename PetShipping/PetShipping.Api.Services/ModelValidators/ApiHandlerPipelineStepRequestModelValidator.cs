using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiHandlerPipelineStepRequestModelValidator : AbstractApiHandlerPipelineStepRequestModelValidator, IApiHandlerPipelineStepRequestModelValidator
        {
                public ApiHandlerPipelineStepRequestModelValidator(IHandlerPipelineStepRepository handlerPipelineStepRepository)
                        : base(handlerPipelineStepRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model)
                {
                        this.HandlerIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model)
                {
                        this.HandlerIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>fa8037d893268722ec4e0e0dcfaa00bf</Hash>
</Codenesium>*/
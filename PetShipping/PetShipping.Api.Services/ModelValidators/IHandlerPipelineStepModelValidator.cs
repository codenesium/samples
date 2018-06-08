using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiHandlerPipelineStepRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiHandlerPipelineStepRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerPipelineStepRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f1d6ff56e7dcdaa30cb88ad6a84987c7</Hash>
</Codenesium>*/
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>a95a3f8177b7c62c057a8e0e5608ce14</Hash>
</Codenesium>*/
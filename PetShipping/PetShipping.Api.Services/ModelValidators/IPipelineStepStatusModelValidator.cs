using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f7153876a00b3c0bc6a7d13663ed17ef</Hash>
</Codenesium>*/
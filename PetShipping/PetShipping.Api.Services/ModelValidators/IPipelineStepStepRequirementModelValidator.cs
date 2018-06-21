using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepStepRequirementRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2ea1ab58a01c779ca044ec27b0dae3db</Hash>
</Codenesium>*/
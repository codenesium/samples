using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepDestinationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>70c462e91bceeb23bb83db734aecf3ec</Hash>
</Codenesium>*/
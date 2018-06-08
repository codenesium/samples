using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

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
    <Hash>cfc5ce3ff36ad7a91a03f80f04300df1</Hash>
</Codenesium>*/
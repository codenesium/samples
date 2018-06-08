using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStepRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>48e292218e07098f444ea18088bdcbca</Hash>
</Codenesium>*/
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>25535d6c7416d49a03f2a8b381e640c6</Hash>
</Codenesium>*/
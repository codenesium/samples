using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>9d37d9d58998e5c28c1b8d6e4b0db2b0</Hash>
</Codenesium>*/
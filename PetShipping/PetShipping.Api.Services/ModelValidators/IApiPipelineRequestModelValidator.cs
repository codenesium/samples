using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>db9d1641377618fa3dd3962e2f1d3a99</Hash>
</Codenesium>*/
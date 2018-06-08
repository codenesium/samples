using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

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
    <Hash>2196d57940b79bedf819949e2b56a7f2</Hash>
</Codenesium>*/
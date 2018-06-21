using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiPipelineStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f7c092e6dd5da79ef03d7fb5fe04947f</Hash>
</Codenesium>*/
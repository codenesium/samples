using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiHandlerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1011568fb4fb898774687b25eeabefa9</Hash>
</Codenesium>*/
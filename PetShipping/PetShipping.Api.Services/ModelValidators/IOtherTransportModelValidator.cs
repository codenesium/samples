using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiOtherTransportRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>577ad4ffbc8e524aaf21b7c2b8857990</Hash>
</Codenesium>*/
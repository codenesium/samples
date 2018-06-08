using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiDestinationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>cbc806dc0d083ebe62604a5c9f295b51</Hash>
</Codenesium>*/
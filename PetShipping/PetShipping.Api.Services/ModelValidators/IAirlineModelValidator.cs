using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiAirlineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b9da4c57708a32e62a1a39e53b39398b</Hash>
</Codenesium>*/
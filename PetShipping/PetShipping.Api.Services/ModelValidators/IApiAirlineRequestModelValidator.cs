using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>06b78bc8003df07484cf158e8441b3d9</Hash>
</Codenesium>*/
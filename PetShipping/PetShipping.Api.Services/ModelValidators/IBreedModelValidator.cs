using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiBreedRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>217b1253fbf1ea18b22d5111fe77e040</Hash>
</Codenesium>*/
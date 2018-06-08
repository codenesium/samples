using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

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
    <Hash>8baf5ce7129eec941bedd332d0ee2a01</Hash>
</Codenesium>*/
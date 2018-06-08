using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiPetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>41683064708ac6e4a549a3d7944db825</Hash>
</Codenesium>*/
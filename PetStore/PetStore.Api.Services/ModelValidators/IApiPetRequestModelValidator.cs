using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface IApiPetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>9155c6e30af053c8660be4e320015b4e</Hash>
</Codenesium>*/
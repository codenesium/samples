using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

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
    <Hash>185ed62a8e3a01ba01f5d7e0fac31e2c</Hash>
</Codenesium>*/
using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.Services
{
        public interface IApiBreedRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>3f8b85f6182f6f5a4c051b40419362e9</Hash>
</Codenesium>*/
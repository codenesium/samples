using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface IApiPenRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2a48e940f4d7342bd8afc064f14f48bb</Hash>
</Codenesium>*/
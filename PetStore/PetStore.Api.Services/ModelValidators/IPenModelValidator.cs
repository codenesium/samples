using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

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
    <Hash>87f005e90b3a8c32ee2804e2d3d569cc</Hash>
</Codenesium>*/
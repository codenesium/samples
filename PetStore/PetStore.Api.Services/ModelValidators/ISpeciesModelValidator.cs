using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.Services
{
        public interface IApiSpeciesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>01b9add93d02c52ecfc2ccc0a989aa86</Hash>
</Codenesium>*/
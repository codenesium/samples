using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiSpeciesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>68b774b22600c52615ab9c120a31960f</Hash>
</Codenesium>*/
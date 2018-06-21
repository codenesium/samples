using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>f0186a57b824e51913681c110d978263</Hash>
</Codenesium>*/
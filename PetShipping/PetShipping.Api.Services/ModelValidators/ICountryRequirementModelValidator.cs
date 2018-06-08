using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiCountryRequirementRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>10852e090641bdc00cc40582f64f8830</Hash>
</Codenesium>*/
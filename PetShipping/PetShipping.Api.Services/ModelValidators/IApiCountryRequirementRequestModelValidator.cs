using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>547d47ad8cebc856360b59abb1a9bc4d</Hash>
</Codenesium>*/
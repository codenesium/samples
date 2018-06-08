using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiCountryRequirementRequestModelValidator: AbstractApiCountryRequirementRequestModelValidator, IApiCountryRequirementRequestModelValidator
        {
                public ApiCountryRequirementRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementRequestModel model)
                {
                        this.CountryIdRules();
                        this.DetailsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementRequestModel model)
                {
                        this.CountryIdRules();
                        this.DetailsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9a239614d00b5de90f536a36aea66362</Hash>
</Codenesium>*/
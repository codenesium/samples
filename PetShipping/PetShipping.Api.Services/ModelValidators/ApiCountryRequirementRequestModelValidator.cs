using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiCountryRequirementRequestModelValidator : AbstractApiCountryRequirementRequestModelValidator, IApiCountryRequirementRequestModelValidator
        {
                public ApiCountryRequirementRequestModelValidator(ICountryRequirementRepository countryRequirementRepository)
                        : base(countryRequirementRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c1fd6017240829e112709331279f7681</Hash>
</Codenesium>*/
using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCountryRegionRequestModelValidator: AbstractApiCountryRegionRequestModelValidator, IApiCountryRegionRequestModelValidator
        {
                public ApiCountryRegionRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>11f4f33f4a5d7fd05ad74cff15d601a7</Hash>
</Codenesium>*/
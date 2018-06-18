using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiCountryRequestModelValidator: AbstractApiCountryRequestModelValidator, IApiCountryRequestModelValidator
        {
                public ApiCountryRequestModelValidator(ICountryRepository countryRepository)
                        : base(countryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9cdc293c7d239658ef7e739593c8970f</Hash>
</Codenesium>*/
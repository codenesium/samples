using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmployeePayHistoryRequestModelValidator: AbstractApiEmployeePayHistoryRequestModelValidator, IApiEmployeePayHistoryRequestModelValidator
        {
                public ApiEmployeePayHistoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PayFrequencyRules();
                        this.RateRules();
                        this.RateChangeDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.PayFrequencyRules();
                        this.RateRules();
                        this.RateChangeDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>5d15cc6a09f55fda3368e6ef8b29c8fe</Hash>
</Codenesium>*/
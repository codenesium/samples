using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCreditCardRequestModelValidator : AbstractApiCreditCardRequestModelValidator, IApiCreditCardRequestModelValidator
        {
                public ApiCreditCardRequestModelValidator(ICreditCardRepository creditCardRepository)
                        : base(creditCardRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model)
                {
                        this.CardNumberRules();
                        this.CardTypeRules();
                        this.ExpMonthRules();
                        this.ExpYearRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model)
                {
                        this.CardNumberRules();
                        this.CardTypeRules();
                        this.ExpMonthRules();
                        this.ExpYearRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>5ccf9aff88e0edd9970c9fbf99d156ae</Hash>
</Codenesium>*/
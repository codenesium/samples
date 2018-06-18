using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiCreditCardRequestModelValidator: AbstractApiCreditCardRequestModelValidator, IApiCreditCardRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d89d8d2d8ebe8f06015461e966e51a2a</Hash>
</Codenesium>*/
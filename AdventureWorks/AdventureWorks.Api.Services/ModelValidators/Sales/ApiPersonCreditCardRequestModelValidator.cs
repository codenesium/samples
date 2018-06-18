using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPersonCreditCardRequestModelValidator: AbstractApiPersonCreditCardRequestModelValidator, IApiPersonCreditCardRequestModelValidator
        {
                public ApiPersonCreditCardRequestModelValidator(IPersonCreditCardRepository personCreditCardRepository)
                        : base(personCreditCardRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model)
                {
                        this.CreditCardIDRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model)
                {
                        this.CreditCardIDRules();
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
    <Hash>72b462b2e7f359c4a0ecd4bb3262b020</Hash>
</Codenesium>*/
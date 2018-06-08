using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiPersonCreditCardRequestModelValidator: AbstractApiPersonCreditCardRequestModelValidator, IApiPersonCreditCardRequestModelValidator
        {
                public ApiPersonCreditCardRequestModelValidator()
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
    <Hash>49817ccdc07dbd199f3c9c1d6aec67f4</Hash>
</Codenesium>*/
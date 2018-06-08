using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmailAddressRequestModelValidator: AbstractApiEmailAddressRequestModelValidator, IApiEmailAddressRequestModelValidator
        {
                public ApiEmailAddressRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model)
                {
                        this.EmailAddress1Rules();
                        this.EmailAddressIDRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model)
                {
                        this.EmailAddress1Rules();
                        this.EmailAddressIDRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>6d691c87e72a4b291e8774822602134b</Hash>
</Codenesium>*/
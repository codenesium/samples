using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiEmailAddressRequestModelValidator : AbstractApiEmailAddressRequestModelValidator, IApiEmailAddressRequestModelValidator
        {
                public ApiEmailAddressRequestModelValidator(IEmailAddressRepository emailAddressRepository)
                        : base(emailAddressRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>93c8034f062702d4aa6fc34fba19b8a8</Hash>
</Codenesium>*/
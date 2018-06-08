using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiBusinessEntityAddressRequestModelValidator: AbstractApiBusinessEntityAddressRequestModelValidator, IApiBusinessEntityAddressRequestModelValidator
        {
                public ApiBusinessEntityAddressRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model)
                {
                        this.AddressIDRules();
                        this.AddressTypeIDRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model)
                {
                        this.AddressIDRules();
                        this.AddressTypeIDRules();
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
    <Hash>69eaefdb91f9688a3946d8d4ff6938b0</Hash>
</Codenesium>*/
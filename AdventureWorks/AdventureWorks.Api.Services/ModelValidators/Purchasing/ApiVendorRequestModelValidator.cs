using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiVendorRequestModelValidator: AbstractApiVendorRequestModelValidator, IApiVendorRequestModelValidator
        {
                public ApiVendorRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiVendorRequestModel model)
                {
                        this.AccountNumberRules();
                        this.ActiveFlagRules();
                        this.CreditRatingRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.PreferredVendorStatusRules();
                        this.PurchasingWebServiceURLRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorRequestModel model)
                {
                        this.AccountNumberRules();
                        this.ActiveFlagRules();
                        this.CreditRatingRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.PreferredVendorStatusRules();
                        this.PurchasingWebServiceURLRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>ab08f4e992181f7e5918a29ace62c5fb</Hash>
</Codenesium>*/
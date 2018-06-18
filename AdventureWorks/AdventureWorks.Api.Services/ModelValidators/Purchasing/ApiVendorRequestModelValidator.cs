using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiVendorRequestModelValidator: AbstractApiVendorRequestModelValidator, IApiVendorRequestModelValidator
        {
                public ApiVendorRequestModelValidator(IVendorRepository vendorRepository)
                        : base(vendorRepository)
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
    <Hash>57740dd002413621d038b090f24c0148</Hash>
</Codenesium>*/
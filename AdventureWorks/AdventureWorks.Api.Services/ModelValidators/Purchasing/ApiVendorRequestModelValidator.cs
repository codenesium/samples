using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiVendorRequestModelValidator : AbstractApiVendorRequestModelValidator, IApiVendorRequestModelValidator
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
                        this.PreferredVendorStatuRules();
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
                        this.PreferredVendorStatuRules();
                        this.PurchasingWebServiceURLRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>e3e00696bfa940431c54787f397fd0a7</Hash>
</Codenesium>*/
using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiVendorModelValidator: AbstractApiVendorModelValidator, IApiVendorModelValidator
	{
		public ApiVendorModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiVendorModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorModel model)
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

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4683f091f9df35a1a68dedf446ccc98b</Hash>
</Codenesium>*/
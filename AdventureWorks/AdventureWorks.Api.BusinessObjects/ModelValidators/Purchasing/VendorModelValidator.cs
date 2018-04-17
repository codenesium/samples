using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class VendorModelValidator: AbstractVendorModelValidator, IVendorModelValidator
	{
		public VendorModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(VendorModel model)
		{
			this.AccountNumberRules();
			this.NameRules();
			this.CreditRatingRules();
			this.PreferredVendorStatusRules();
			this.ActiveFlagRules();
			this.PurchasingWebServiceURLRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, VendorModel model)
		{
			this.AccountNumberRules();
			this.NameRules();
			this.CreditRatingRules();
			this.PreferredVendorStatusRules();
			this.ActiveFlagRules();
			this.PurchasingWebServiceURLRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>34b9355125e26c671ecdb6aadad71107</Hash>
</Codenesium>*/
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
			this.ActiveFlagRules();
			this.CreditRatingRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.PreferredVendorStatusRules();
			this.PurchasingWebServiceURLRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, VendorModel model)
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
    <Hash>8c750c59298854e602e72f93b35c2166</Hash>
</Codenesium>*/
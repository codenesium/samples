using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiVendorServerRequestModelValidator : AbstractApiVendorServerRequestModelValidator, IApiVendorServerRequestModelValidator
	{
		public ApiVendorServerRequestModelValidator(IVendorRepository vendorRepository)
			: base(vendorRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVendorServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorServerRequestModel model)
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
    <Hash>401c71a948d6d6e90bd59a0778a26ba7</Hash>
</Codenesium>*/
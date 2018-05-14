using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBusinessEntityAddressModelValidator: AbstractApiBusinessEntityAddressModelValidator, IApiBusinessEntityAddressModelValidator
	{
		public ApiBusinessEntityAddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressModel model)
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressModel model)
		{
			this.AddressIDRules();
			this.AddressTypeIDRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>fbaee73077169261c4c24057e421c724</Hash>
</Codenesium>*/
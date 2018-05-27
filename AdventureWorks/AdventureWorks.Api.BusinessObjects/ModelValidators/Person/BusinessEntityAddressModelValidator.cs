using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBusinessEntityAddressRequestModelValidator: AbstractApiBusinessEntityAddressRequestModelValidator, IApiBusinessEntityAddressRequestModelValidator
	{
		public ApiBusinessEntityAddressRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4b3cd3ba175703cb9c90218174b02576</Hash>
</Codenesium>*/
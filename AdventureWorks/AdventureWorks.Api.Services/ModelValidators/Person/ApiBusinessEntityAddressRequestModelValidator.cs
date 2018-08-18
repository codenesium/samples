using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBusinessEntityAddressRequestModelValidator : AbstractApiBusinessEntityAddressRequestModelValidator, IApiBusinessEntityAddressRequestModelValidator
	{
		public ApiBusinessEntityAddressRequestModelValidator(IBusinessEntityAddressRepository businessEntityAddressRepository)
			: base(businessEntityAddressRepository)
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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>23efb3d959827092b6dc2928695f18f9</Hash>
</Codenesium>*/
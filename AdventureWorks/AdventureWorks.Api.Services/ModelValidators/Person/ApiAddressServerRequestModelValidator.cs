using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiAddressServerRequestModelValidator : AbstractApiAddressServerRequestModelValidator, IApiAddressServerRequestModelValidator
	{
		public ApiAddressServerRequestModelValidator(IAddressRepository addressRepository)
			: base(addressRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressServerRequestModel model)
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.ModifiedDateRules();
			this.PostalCodeRules();
			this.RowguidRules();
			this.StateProvinceIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressServerRequestModel model)
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.ModifiedDateRules();
			this.PostalCodeRules();
			this.RowguidRules();
			this.StateProvinceIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>222fa8c54cd1b7cc1937c5511bcf5d26</Hash>
</Codenesium>*/
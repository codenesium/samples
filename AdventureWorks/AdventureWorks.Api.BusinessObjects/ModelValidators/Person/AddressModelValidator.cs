using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiAddressRequestModelValidator: AbstractApiAddressRequestModelValidator, IApiAddressRequestModelValidator
	{
		public ApiAddressRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model)
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

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>917dd56b3e40c308a8b4029b36193c9a</Hash>
</Codenesium>*/
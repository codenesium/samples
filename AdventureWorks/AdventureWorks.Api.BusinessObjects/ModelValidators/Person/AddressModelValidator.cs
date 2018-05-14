using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiAddressModelValidator: AbstractApiAddressModelValidator, IApiAddressModelValidator
	{
		public ApiAddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressModel model)
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.ModifiedDateRules();
			this.PostalCodeRules();
			this.RowguidRules();
			this.SpatialLocationRules();
			this.StateProvinceIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressModel model)
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.ModifiedDateRules();
			this.PostalCodeRules();
			this.RowguidRules();
			this.SpatialLocationRules();
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
    <Hash>da8ec9267dcbff325f5b9ef60b32689c</Hash>
</Codenesium>*/
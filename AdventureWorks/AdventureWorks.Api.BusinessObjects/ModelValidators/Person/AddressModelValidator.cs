using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class AddressModelValidator: AbstractAddressModelValidator, IAddressModelValidator
	{
		public AddressModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(AddressModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AddressModel model)
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
    <Hash>d005a7742765c8d13a017d9c9a706f4c</Hash>
</Codenesium>*/
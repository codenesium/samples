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
			this.StateProvinceIDRules();
			this.PostalCodeRules();
			this.SpatialLocationRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, AddressModel model)
		{
			this.AddressLine1Rules();
			this.AddressLine2Rules();
			this.CityRules();
			this.StateProvinceIDRules();
			this.PostalCodeRules();
			this.SpatialLocationRules();
			this.RowguidRules();
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
    <Hash>4766cc300f9d854f2799ee475cf39118</Hash>
</Codenesium>*/
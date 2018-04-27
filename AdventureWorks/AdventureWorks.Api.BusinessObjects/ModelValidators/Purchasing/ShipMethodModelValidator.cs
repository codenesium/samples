using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ShipMethodModelValidator: AbstractShipMethodModelValidator, IShipMethodModelValidator
	{
		public ShipMethodModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ShipMethodModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShipMethodModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>fe9a194c4534f450bd38cab8d0de986c</Hash>
</Codenesium>*/
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
			this.NameRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ShipMethodModel model)
		{
			this.NameRules();
			this.ShipBaseRules();
			this.ShipRateRules();
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
    <Hash>3bf71dbf0205e51ceb384892a1b3b115</Hash>
</Codenesium>*/
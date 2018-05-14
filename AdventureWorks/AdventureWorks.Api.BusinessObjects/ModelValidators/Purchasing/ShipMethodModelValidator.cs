using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiShipMethodModelValidator: AbstractApiShipMethodModelValidator, IApiShipMethodModelValidator
	{
		public ApiShipMethodModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiShipMethodModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodModel model)
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
    <Hash>0c67d75852ec7938eee1c485ff7c5835</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShipMethodServerRequestModelValidator : AbstractApiShipMethodServerRequestModelValidator, IApiShipMethodServerRequestModelValidator
	{
		public ApiShipMethodServerRequestModelValidator(IShipMethodRepository shipMethodRepository)
			: base(shipMethodRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiShipMethodServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.ShipBaseRules();
			this.ShipRateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e88b9854f94231f6adbe446bf4f3a677</Hash>
</Codenesium>*/
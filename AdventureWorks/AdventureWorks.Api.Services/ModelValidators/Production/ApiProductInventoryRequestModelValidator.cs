using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductInventoryRequestModelValidator : AbstractApiProductInventoryRequestModelValidator, IApiProductInventoryRequestModelValidator
	{
		public ApiProductInventoryRequestModelValidator(IProductInventoryRepository productInventoryRepository)
			: base(productInventoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>68803f50dfb52edf93862548492666e3</Hash>
</Codenesium>*/
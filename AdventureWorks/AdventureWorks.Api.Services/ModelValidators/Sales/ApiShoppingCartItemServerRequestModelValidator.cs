using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShoppingCartItemServerRequestModelValidator : AbstractApiShoppingCartItemServerRequestModelValidator, IApiShoppingCartItemServerRequestModelValidator
	{
		public ApiShoppingCartItemServerRequestModelValidator(IShoppingCartItemRepository shoppingCartItemRepository)
			: base(shoppingCartItemRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemServerRequestModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemServerRequestModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>898d9065b0a938f22476b0bb322ce89d</Hash>
</Codenesium>*/
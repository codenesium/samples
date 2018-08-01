using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiShoppingCartItemRequestModelValidator : AbstractApiShoppingCartItemRequestModelValidator, IApiShoppingCartItemRequestModelValidator
	{
		public ApiShoppingCartItemRequestModelValidator(IShoppingCartItemRepository shoppingCartItemRepository)
			: base(shoppingCartItemRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model)
		{
			this.DateCreatedRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ShoppingCartIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model)
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
    <Hash>e5f3bfe5647e9413403a8b7b8b591881</Hash>
</Codenesium>*/
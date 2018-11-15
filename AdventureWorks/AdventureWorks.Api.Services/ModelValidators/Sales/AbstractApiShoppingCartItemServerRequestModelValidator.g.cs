using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiShoppingCartItemServerRequestModelValidator : AbstractValidator<ApiShoppingCartItemServerRequestModel>
	{
		private int existingRecordId;

		private IShoppingCartItemRepository shoppingCartItemRepository;

		public AbstractApiShoppingCartItemServerRequestModelValidator(IShoppingCartItemRepository shoppingCartItemRepository)
		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiShoppingCartItemServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void QuantityRules()
		{
		}

		public virtual void ShoppingCartIDRules()
		{
			this.RuleFor(x => x.ShoppingCartID).NotNull();
			this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>08d420abe586d748fb13ceeea47b12c9</Hash>
</Codenesium>*/
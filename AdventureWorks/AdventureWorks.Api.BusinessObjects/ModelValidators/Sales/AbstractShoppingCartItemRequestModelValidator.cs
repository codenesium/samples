using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShoppingCartItemRequestModelValidator: AbstractValidator<ApiShoppingCartItemRequestModel>
	{
		public new ValidationResult Validate(ApiShoppingCartItemRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShoppingCartItemRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DateCreatedRules()
		{
			this.RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ShoppingCartIDRules()
		{
			this.RuleFor(x => x.ShoppingCartID).NotNull();
			this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>6ca1eab0691ce570afebb152e92be704</Hash>
</Codenesium>*/
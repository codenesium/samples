using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractShoppingCartItemModelValidator: AbstractValidator<ShoppingCartItemModel>
	{
		public new ValidationResult Validate(ShoppingCartItemModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ShoppingCartItemModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository { get; set; }
		public virtual void ShoppingCartIDRules()
		{
			this.RuleFor(x => x.ShoppingCartID).NotNull();
			this.RuleFor(x => x.ShoppingCartID).Length(0, 50);
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).Must(this.BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void DateCreatedRules()
		{
			this.RuleFor(x => x.DateCreated).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>a6f321e7062a547341af647a13e1cdaf</Hash>
</Codenesium>*/
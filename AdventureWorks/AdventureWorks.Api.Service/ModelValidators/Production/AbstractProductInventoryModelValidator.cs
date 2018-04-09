using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductInventoryModelValidator: AbstractValidator<ProductInventoryModel>
	{
		public new ValidationResult Validate(ProductInventoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductInventoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository {get; set;}
		public ILocationRepository LocationRepository {get; set;}
		public virtual void LocationIDRules()
		{
			RuleFor(x => x.LocationID).NotNull();
			RuleFor(x => x.LocationID).Must(BeValidLocation).When(x => x ?.LocationID != null).WithMessage("Invalid reference");
		}

		public virtual void ShelfRules()
		{
			RuleFor(x => x.Shelf).NotNull();
			RuleFor(x => x.Shelf).Length(0,10);
		}

		public virtual void BinRules()
		{
			RuleFor(x => x.Bin).NotNull();
		}

		public virtual void QuantityRules()
		{
			RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidLocation(short id)
		{
			return this.LocationRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>724257058f310eda9103272460e219f4</Hash>
</Codenesium>*/
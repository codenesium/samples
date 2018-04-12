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

		public IProductRepository ProductRepository { get; set; }
		public ILocationRepository LocationRepository { get; set; }
		public virtual void LocationIDRules()
		{
			this.RuleFor(x => x.LocationID).NotNull();
			this.RuleFor(x => x.LocationID).Must(this.BeValidLocation).When(x => x ?.LocationID != null).WithMessage("Invalid reference");
		}

		public virtual void ShelfRules()
		{
			this.RuleFor(x => x.Shelf).NotNull();
			this.RuleFor(x => x.Shelf).Length(0, 10);
		}

		public virtual void BinRules()
		{
			this.RuleFor(x => x.Bin).NotNull();
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
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
    <Hash>8ce418b36d66f0ad1b1455a2f159ec16</Hash>
</Codenesium>*/
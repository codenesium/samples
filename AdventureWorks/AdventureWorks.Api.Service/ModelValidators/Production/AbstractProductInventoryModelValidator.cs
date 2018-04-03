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

		public virtual void LocationIDRules()
		{
			RuleFor(x => x.LocationID).NotNull();
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
	}
}

/*<Codenesium>
    <Hash>46c2e78d264edc8a050080343ede7d1a</Hash>
</Codenesium>*/
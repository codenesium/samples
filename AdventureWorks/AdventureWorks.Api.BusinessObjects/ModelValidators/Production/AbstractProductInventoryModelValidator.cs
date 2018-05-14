using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductInventoryModelValidator: AbstractValidator<ApiProductInventoryModel>
	{
		public new ValidationResult Validate(ApiProductInventoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductInventoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void BinRules()
		{
			this.RuleFor(x => x.Bin).NotNull();
		}

		public virtual void LocationIDRules()
		{
			this.RuleFor(x => x.LocationID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ShelfRules()
		{
			this.RuleFor(x => x.Shelf).NotNull();
			this.RuleFor(x => x.Shelf).Length(0, 10);
		}
	}
}

/*<Codenesium>
    <Hash>475b2d2bc76fe8510c55fa795c753e70</Hash>
</Codenesium>*/
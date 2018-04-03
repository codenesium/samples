using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSpecialOfferProductModelValidator: AbstractValidator<SpecialOfferProductModel>
	{
		public new ValidationResult Validate(SpecialOfferProductModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SpecialOfferProductModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
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
    <Hash>cdcfd9894c1d14d336443266e6a75535</Hash>
</Codenesium>*/
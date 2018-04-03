using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductProductPhotoModelValidator: AbstractValidator<ProductProductPhotoModel>
	{
		public new ValidationResult Validate(ProductProductPhotoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductProductPhotoModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductPhotoIDRules()
		{
			RuleFor(x => x.ProductPhotoID).NotNull();
		}

		public virtual void PrimaryRules()
		{
			RuleFor(x => x.Primary).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>299ae28e49a8f7be1d18a26f9bea8d39</Hash>
</Codenesium>*/
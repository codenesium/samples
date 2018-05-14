using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductProductPhotoModelValidator: AbstractValidator<ApiProductProductPhotoModel>
	{
		public new ValidationResult Validate(ApiProductProductPhotoModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductProductPhotoModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PrimaryRules()
		{
			this.RuleFor(x => x.Primary).NotNull();
		}

		public virtual void ProductPhotoIDRules()
		{
			this.RuleFor(x => x.ProductPhotoID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>8847a70ed87d2f146c7a17bbfd281649</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductModelIllustrationModelValidator: AbstractValidator<ProductModelIllustrationModel>
	{
		public new ValidationResult Validate(ProductModelIllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductModelIllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void IllustrationIDRules()
		{
			RuleFor(x => x.IllustrationID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>5e1b9197adbda1e58e71292c1cc98f5d</Hash>
</Codenesium>*/
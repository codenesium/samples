using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductModelIllustrationModelValidator: AbstractValidator<ApiProductModelIllustrationModel>
	{
		public new ValidationResult Validate(ApiProductModelIllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void IllustrationIDRules()
		{
			this.RuleFor(x => x.IllustrationID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>4e644d7dc0df16d54caa6ad2288eff84</Hash>
</Codenesium>*/
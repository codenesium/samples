using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductModelIllustrationRequestModelValidator: AbstractValidator<ApiProductModelIllustrationRequestModel>
	{
		public new ValidationResult Validate(ApiProductModelIllustrationRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationRequestModel model)
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
    <Hash>c2a1f0f98bc98b0d9b02fa796067346d</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiIllustrationModelValidator: AbstractValidator<ApiIllustrationModel>
	{
		public new ValidationResult Validate(ApiIllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiIllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DiagramRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>570f6d4d8d915b179abeda34a744532a</Hash>
</Codenesium>*/
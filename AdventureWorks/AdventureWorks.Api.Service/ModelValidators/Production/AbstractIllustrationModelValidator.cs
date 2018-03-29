using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractIllustrationModelValidator: AbstractValidator<IllustrationModel>
	{
		public new ValidationResult Validate(IllustrationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(IllustrationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DiagramRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>a15ded1a98d92c72601dd4b45a3972b5</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>65348e3ff2c74a6d82c6c56edcd7bbb1</Hash>
</Codenesium>*/
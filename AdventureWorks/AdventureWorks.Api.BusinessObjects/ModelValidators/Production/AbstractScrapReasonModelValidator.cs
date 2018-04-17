using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractScrapReasonModelValidator: AbstractValidator<ScrapReasonModel>
	{
		public new ValidationResult Validate(ScrapReasonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ScrapReasonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>b4851d3f53ad72f0c33ede19eb3016b7</Hash>
</Codenesium>*/
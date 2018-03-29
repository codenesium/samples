using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractUnitMeasureModelValidator: AbstractValidator<UnitMeasureModel>
	{
		public new ValidationResult Validate(UnitMeasureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(UnitMeasureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>cbc5110b1ab58513de1b31139f1c97b4</Hash>
</Codenesium>*/
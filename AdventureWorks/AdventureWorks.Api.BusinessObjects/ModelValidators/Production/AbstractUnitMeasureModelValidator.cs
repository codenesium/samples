using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
    <Hash>9a1dd0854a07da57e2045fe1478f28a6</Hash>
</Codenesium>*/
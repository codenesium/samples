using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractLocationModelValidator: AbstractValidator<LocationModel>
	{
		public new ValidationResult Validate(LocationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LocationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void CostRateRules()
		{
			RuleFor(x => x.CostRate).NotNull();
		}

		public virtual void AvailabilityRules()
		{
			RuleFor(x => x.Availability).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>8c5255662a232334836842525d7c2699</Hash>
</Codenesium>*/